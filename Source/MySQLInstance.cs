﻿//
// Copyright (c) 2013, Oracle and/or its affiliates. All rights reserved.
//
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License as
// published by the Free Software Foundation; version 2 of the
// License.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA
// 02110-1301  USA
//

namespace MySql.Notifier
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.Linq;
  using System.Windows.Forms;
  using System.Xml;
  using System.Xml.Serialization;
  using MySql.Data.MySqlClient;
  using MySQL.Utility;

  /// <summary>
  /// A MySQL Server instance that can be reached through a <see cref="MySqlWorkbenchConnection"/>.
  /// </summary>
  [Serializable]
  public class MySQLInstance : INotifyPropertyChanged
  {
    /// <summary>
    /// Default monitoring interval in seconds for a MySQL instance, set to 10 minutes.
    /// </summary>
    public const int DEFAULT_MONITORING_INTERVAL = 10;

    /// <summary>
    /// Default monitoring interval unit of measures, set to seconds by default.
    /// </summary>
    public const IntervalUnitOfMeasure DEFAULT_MONITORING_UOM = IntervalUnitOfMeasure.Minutes;

    #region Fields

    /// <summary>
    /// Flag indicating if this instance is being monitored and status changes notified to users.
    /// </summary>
    private bool _monitorAndNotifyStatus;

    /// <summary>
    /// The monitoring interval for this MySQL instance.
    /// </summary>
    private uint _monitoringInterval;

    /// <summary>
    /// The unit of measure used for this instance's monitoring instance.
    /// </summary>
    private IntervalUnitOfMeasure _monitoringIntervalUnitOfMeasure;

    /// <summary>
    /// The connection status of the instance before testing the connection for a new status.
    /// </summary>
    private MySqlWorkbenchConnection.ConnectionStatusType _oldInstanceStatus;

    /// <summary>
    /// The list of Workbench connections that connect to this MySQL instance.
    /// </summary>
    private List<MySqlWorkbenchConnection> _relatedConnections;

    /// <summary>
    /// The seconds remaining to the next connection test for the monitoring of this instance.
    /// </summary>
    private double _secondsToMonitorInstance;

    /// <summary>
    /// Flag indicating whether status changes of this instance trigger an update of the tray icon.
    /// </summary>
    private bool _updateTrayIconOnStatusChange;

    /// <summary>
    /// A <see cref="MySqlWorkbenchConnection"/> object with the connection properties for this instance.
    /// </summary>
    private MySqlWorkbenchConnection _workbenchConnection;

    /// <summary>
    /// The Id of the <see cref="MySqlWorkbenchConnection"/> connection.
    /// </summary>
    private string _workbenchConnectionId;

    #endregion Fields

    /// <summary>
    /// Initializes a new instance of the <see cref="MySQLInstance"/> class.
    /// </summary>
    public MySQLInstance()
    {
      _workbenchConnectionId = string.Empty;
      _monitoringInterval = DEFAULT_MONITORING_INTERVAL;
      _monitoringIntervalUnitOfMeasure = DEFAULT_MONITORING_UOM;
      _monitorAndNotifyStatus = true;
      _relatedConnections = null;
      _oldInstanceStatus = MySqlWorkbenchConnection.ConnectionStatusType.Unknown;
      _updateTrayIconOnStatusChange = true;
      _workbenchConnection = null;
      ConnectionTestInProgress = false;
      MenuGroup = null;
      SecondsToMonitorInstance = MonitoringIntervalInSeconds;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MySQLInstance"/> class.
    /// </summary>
    /// <param name="workbenchConnection">A <see cref="MySqlWorkbenchConnection"/> object.</param>
    public MySQLInstance(MySqlWorkbenchConnection workbenchConnection)
      : this()
    {
      WorkbenchConnection = workbenchConnection;
    }

    /// <summary>
    /// Unit of measure used for time intervals.
    /// </summary>
    public enum IntervalUnitOfMeasure
    {
      /// <summary>
      /// Interval measured in seconds.
      /// </summary>
      Seconds = 0,

      /// <summary>
      /// Interval measured in minutes.
      /// </summary>
      Minutes = 1,

      /// <summary>
      /// Interval measured in hours.
      /// </summary>
      Hours = 2,

      /// <summary>
      /// Interval measured in days.
      /// </summary>
      Days = 3
    }

    #region Events

    /// <summary>
    /// Event occurring when a property value changes.
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// Event handler delegate for the <see cref="InstanceStatusChanged"/> event.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="args">Event arguments.</param>
    public delegate void InstanceStatusChangedEventHandler(object sender, InstanceStatusChangedArgs args);

    /// <summary>
    /// Event ocurring when the status of the current instance changes.
    /// </summary>
    public event InstanceStatusChangedEventHandler InstanceStatusChanged;

    /// <summary>
    /// Event handler delegate for the <see cref="InstanceStatusChanged"/> event.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="args">Event arguments.</param>
    public delegate void InstanceConnectionStatusTestErrorEventHandler(object sender, InstanceConnectionStatusTestErrorThrownArgs args);

    /// <summary>
    /// Event ocurring when an error ocurred during a connection status test.
    /// </summary>
    public event InstanceConnectionStatusTestErrorEventHandler InstanceConnectionStatusTestErrorThrown;

    #endregion Events

    #region Properties

    /// <summary>
    /// Gets the status of this isntance's connection.
    /// </summary>
    [XmlIgnore]
    public MySqlWorkbenchConnection.ConnectionStatusType ConnectionStatus
    {
      get
      {
        return WorkbenchConnection != null ? WorkbenchConnection.ConnectionStatus : MySqlWorkbenchConnection.ConnectionStatusType.Unknown;
      }
    }

    /// <summary>
    /// Gets a description on the status of this instance's connection.
    /// </summary>
    [XmlIgnore]
    public string ConnectionStatusText
    {
      get
      {
        return WorkbenchConnection != null ? WorkbenchConnection.ConnectionStatusText : string.Empty;
      }
    }

    /// <summary>
    /// Gets a value indicating whether a connection test is still ongoing.
    /// </summary>
    [XmlIgnore]
    public bool ConnectionTestInProgress { get; private set; }

    /// <summary>
    /// Gets or sets the name of the host of this MySQL instance.
    /// </summary>
    [XmlAttribute(AttributeName = "HostName")]
    public string HostName { get; set; }

    /// <summary>
    /// Gets an identifier for this instance composed of the host name and port normally.
    /// </summary>
    [XmlIgnore]
    public string HostIdentifier
    {
      get
      {
        return WorkbenchConnection != null ? WorkbenchConnection.HostIdentifier : string.Empty;
      }
    }

    /// <summary>
    /// Gets the group of ToolStripMenuItem controls for each of the corresponding instance's context menu items.
    /// </summary>
    [XmlIgnore]
    public MySQLInstanceMenuGroup MenuGroup { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is being monitored and status changes notified to users.
    /// </summary>
    [XmlAttribute(AttributeName = "MonitorAndNotifyStatus")]
    public bool MonitorAndNotifyStatus
    {
      get
      {
        return _monitorAndNotifyStatus;
      }

      set
      {
        bool lastValue = _monitorAndNotifyStatus;
        _monitorAndNotifyStatus = value;
        if (lastValue != value)
        {
          SecondsToMonitorInstance = MonitoringIntervalInSeconds;
          OnPropertyChanged("MonitorAndNotifyStatus");
        }
      }
    }

    /// <summary>
    /// Gets or sets the monitoring interval for this MySQL instance.
    /// </summary>
    [XmlAttribute(AttributeName = "MonitoringInterval")]
    public uint MonitoringInterval
    {
      get
      {
        return _monitoringInterval;
      }

      set
      {
        uint lastValue = _monitoringInterval;
        _monitoringInterval = value;
        if (lastValue != value)
        {
          SecondsToMonitorInstance = MonitoringIntervalInSeconds;
          OnPropertyChanged("MonitoringInterval");
        }
      }
    }

    /// <summary>
    /// Gets the monitoring interval in seconds for this MySQL instance.
    /// </summary>
    [XmlIgnore]
    public double MonitoringIntervalInSeconds
    {
      get
      {
        switch (_monitoringIntervalUnitOfMeasure)
        {
          case IntervalUnitOfMeasure.Seconds:
            return _monitoringInterval;

          case IntervalUnitOfMeasure.Minutes:
            return TimeSpan.FromMinutes(_monitoringInterval).TotalSeconds;

          case IntervalUnitOfMeasure.Hours:
            return TimeSpan.FromHours(_monitoringInterval).TotalSeconds;

          case IntervalUnitOfMeasure.Days:
            return TimeSpan.FromDays(_monitoringInterval).TotalSeconds;
        }

        return 0;
      }
    }

    /// <summary>
    /// Gets or sets the unit of measure used for this instance's monitoring instance.
    /// </summary>
    [XmlAttribute(AttributeName = "MonitoringIntervalUnitOfMeasure")]
    public IntervalUnitOfMeasure MonitoringIntervalUnitOfMeasure
    {
      get
      {
        return _monitoringIntervalUnitOfMeasure;
      }

      set
      {
        IntervalUnitOfMeasure lastValue = _monitoringIntervalUnitOfMeasure;
        _monitoringIntervalUnitOfMeasure = value;
        if (lastValue != value)
        {
          SecondsToMonitorInstance = MonitoringIntervalInSeconds;
          OnPropertyChanged("MonitoringIntervalUnitOfMeasure");
        }
      }
    }

    /// <summary>
    /// Gets or sets the connection port for this MySQL instance.
    /// </summary>
    [XmlAttribute(AttributeName = "Port")]
    public uint Port { get; set; }

    /// <summary>
    /// Gets the list of Workbench connections that connect to this MySQL instance.
    /// </summary>
    [XmlIgnore]
    public List<MySqlWorkbenchConnection> RelatedConnections
    {
      get
      {
        if (_relatedConnections == null)
        {
          _relatedConnections = new List<MySqlWorkbenchConnection>();
          bool isLocalInstance = MySqlWorkbenchConnection.IsHostLocal(HostName);
          foreach (var workbenchConnection in MySqlWorkbench.Connections)
          {
            if (workbenchConnection.Port != Port)
            {
              continue;
            }

            if (string.IsNullOrEmpty(workbenchConnection.Host) && string.IsNullOrEmpty(HostName))
            {
              _relatedConnections.Add(workbenchConnection);
              continue;
            }

            if ((workbenchConnection.IsLocalConnection && isLocalInstance) || (workbenchConnection.Host.ToLowerInvariant() == HostName.ToLowerInvariant()))
            {
              _relatedConnections.Add(workbenchConnection);
            }
          }
        }

        return _relatedConnections;
      }
    }

    /// <summary>
    /// Gets or sets the seconds remaining to the next connection test for the monitoring of this instance.
    /// </summary>
    [XmlIgnore]
    public double SecondsToMonitorInstance
    {
      get
      {
        return _secondsToMonitorInstance;
      }

      set
      {
        _secondsToMonitorInstance = value;
        if (_secondsToMonitorInstance <= 0)
        {
          _secondsToMonitorInstance = MonitoringIntervalInSeconds;
          CheckInstanceStatus(true);
        }

        OnPropertyChanged("SecondsToMonitorInstance");
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether status changes of this instance trigger an update of the tray icon.
    /// </summary>
    [XmlAttribute(AttributeName = "UpdateTrayIconOnStatusChange")]
    public bool UpdateTrayIconOnStatusChange
    {
      get
      {
        return _updateTrayIconOnStatusChange;
      }

      set
      {
        _updateTrayIconOnStatusChange = value;
        OnPropertyChanged("UpdateTrayIconOnStatusChange");
      }
    }

    /// <summary>
    /// Gets a <see cref="MySqlWorkbenchConnection"/> object with the connection properties for this instance.
    /// </summary>
    [XmlIgnore]
    public MySqlWorkbenchConnection WorkbenchConnection
    { 
      get
      {
        return _workbenchConnection;
      }
      
      set
      {
        _workbenchConnection = value;

        //// If the connection is null maybe it was not found anymore so we fallback to use the first found related connection.
        if (_workbenchConnection == null)
        {
          _workbenchConnection = RelatedConnections.First();
        }

        if (_workbenchConnection != null)
        {
          _workbenchConnectionId = _workbenchConnection.Id;
          HostName = _workbenchConnection.Host;
          Port = _workbenchConnection.Port;
        }

        SetupMenuGroup();
        OnPropertyChanged("WorkbenchConnection");
      }
    }

    /// <summary>
    /// Gets or sets the Id of the <see cref="MySqlWorkbenchConnection"/> connection.
    /// </summary>
    [XmlAttribute(AttributeName = "WorkbenchConnectionId")]
    public string WorkbenchConnectionId
    {
      get
      {
        return _workbenchConnectionId;
      }

      set
      {
        _workbenchConnectionId = value;
        if (!string.IsNullOrEmpty(_workbenchConnectionId))
        {
          WorkbenchConnection = MySqlWorkbench.Connections.First(conn => conn.Id == _workbenchConnectionId);
        }

        OnPropertyChanged("WorkbenchConnectionId");
      }
    }

    /// <summary>
    /// Gets a <see cref="MySqlWorkbenchServer"/> object related to this instance's Workbench connection.
    /// </summary>
    [XmlIgnore]
    public MySqlWorkbenchServer WorkbenchServer
    {
      get
      {
        return MySqlWorkbench.Servers.Any(s => s.ConnectionId == WorkbenchConnectionId) ? MySqlWorkbench.Servers.First(s => s.ConnectionId == WorkbenchConnectionId) : null;
      }
    }

    #endregion Properties

    /// <summary>
    /// Checks if this instance can connect to its corresponding MySQL Server instance with its Workbench connection.
    /// </summary>
    /// <param name="asynchronous">Flag indicating if the status check is run asynchronously or synchronously.</param>
    public void CheckInstanceStatus(bool asynchronous)
    {
      if (WorkbenchConnection == null || ConnectionTestInProgress)
      {
        return;
      }

      ConnectionTestInProgress = true;
      _oldInstanceStatus = ConnectionStatus;

      if (asynchronous)
      {
        BackgroundWorker worker = new BackgroundWorker();
        worker.WorkerSupportsCancellation = false;
        worker.WorkerReportsProgress = false;
        worker.DoWork += new DoWorkEventHandler(CheckInstanceStatusWorkerDoWork);
        worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CheckInstanceStatusWorkerCompleted);
        worker.RunWorkerAsync();
      }
      else
      {
        Cursor.Current = Cursors.WaitCursor;
        CheckInstanceStatusWorkerDoWork(this, new DoWorkEventArgs(null));
        CheckInstanceStatusWorkerCompleted(this, new RunWorkerCompletedEventArgs(null, null, false));
        Cursor.Current = Cursors.Default;
      }
    }

    /// <summary>
    /// Initializes the instance's menu group.
    /// </summary>
    public void SetupMenuGroup()
    {
      if (MenuGroup == null)
      {
        MenuGroup = new MySQLInstanceMenuGroup(this);
      }
    }

    /// <summary>
    /// Delegate method that reports the asynchronous operation to test the instance's connection status has completed.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="e">Event arguments.</param>
    private void CheckInstanceStatusWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (ConnectionStatus != _oldInstanceStatus)
      {
        OnInstanceStatusChanged(_oldInstanceStatus);
      }

      ConnectionTestInProgress = false;
    }

    /// <summary>
    /// Delegate method that asynchronously tests the instance's connection status.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="e">Event arguments.</param>
    private void CheckInstanceStatusWorkerDoWork(object sender, DoWorkEventArgs e)
    {
      Exception ex;
      WorkbenchConnection.TestConnection(out ex);
      if (ex != null && ex is MySqlException)
      {
        MySqlException mySqlEx = ex as MySqlException;
        switch (mySqlEx.Number)
        {
          case 1042:
            //// Unable to connect to any of the specified MySQL hosts.
            break;

          default:
            OnInstanceStatusTestErrorThrown(ex);
            break;
        }
      }
    }

    /// <summary>
    /// Fires the <see cref="InstanceStatusChanged"/> event.
    /// </summary>
    /// <param name="oldInstanceStatus">Old instance status.</param>
    private void OnInstanceStatusChanged(MySqlWorkbenchConnection.ConnectionStatusType oldInstanceStatus)
    {
      if (InstanceStatusChanged != null)
      {
        InstanceStatusChanged(this, new InstanceStatusChangedArgs(this, oldInstanceStatus));
      }
    }

    /// <summary>
    /// Fires the <see cref="InstanceConnectionStatusTestErrorThrown"/> event.
    /// </summary>
    /// <param name="ex">Exception thrown by a connection status test.</param>
    private void OnInstanceStatusTestErrorThrown(Exception ex)
    {
      if (InstanceConnectionStatusTestErrorThrown != null)
      {
        InstanceConnectionStatusTestErrorThrown(this, new InstanceConnectionStatusTestErrorThrownArgs(this, ex));
      }
    }

    /// <summary>
    /// Raises the <see cref="PropertyChanged"/> event.
    /// </summary>
    /// <param name="propertyName">The name of the property that changed.</param>
    private void OnPropertyChanged(string propertyName)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }
  }

  /// <summary>
  /// Provides information for the <see cref="InstanceStatusChanged"/> event.
  /// </summary>
  public class InstanceStatusChangedArgs : EventArgs
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="InstanceStatusChangedArgs"/> class.
    /// </summary>
    /// <param name="instance">MySQL instance whose status changed.</param>
    /// <param name="oldInstanceStatus">Old instance status.</param>
    public InstanceStatusChangedArgs(MySQLInstance instance, MySqlWorkbenchConnection.ConnectionStatusType oldInstanceStatus)
    {
      Instance = instance;
      OldInstanceStatus = oldInstanceStatus;
    }

    /// <summary>
    /// Gets the MySQL instance whose status changed.
    /// </summary>
    public MySQLInstance Instance { get; private set; }

    /// <summary>
    /// Gets the new status of the instance.
    /// </summary>
    public MySqlWorkbenchConnection.ConnectionStatusType NewInstanceStatus
    {
      get
      {
        return Instance.ConnectionStatus;
      }
    }

    /// <summary>
    /// Gets a description on the new status of this connection.
    /// </summary>
    public string NewInstanceStatusText
    {
      get
      {
        return Instance.ConnectionStatusText;
      }
    }

    /// <summary>
    /// Gets the old status of the instance.
    /// </summary>
    public MySqlWorkbenchConnection.ConnectionStatusType OldInstanceStatus { get; private set; }

    /// <summary>
    /// Gets a description on the old status of this connection.
    /// </summary>
    public string OldInstanceStatusText
    {
      get
      {
        return MySqlWorkbenchConnection.GetConnectionStatusDisplayText(OldInstanceStatus);
      }
    }
  }

  /// <summary>
  /// Provides information for the <see cref="InstanceConnectionStatusTestErrorThrown"/> event.
  /// </summary>
  public class InstanceConnectionStatusTestErrorThrownArgs : EventArgs
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="InstanceConnectionStatusTestErrorThrownArgs"/> class.
    /// </summary>
    /// <param name="instance">MySQL instance whose status changed.</param>
    /// <param name="ex">Exception thrown during a connection status test.</param>
    public InstanceConnectionStatusTestErrorThrownArgs(MySQLInstance instance, Exception ex)
    {
      Instance = instance;
      ErrorException = ex;
    }

    /// <summary>
    /// Gets the error Exception thrown during a connection status test.
    /// </summary>
    public Exception ErrorException { get; private set; }

    /// <summary>
    /// Gets the MySQL instance whose status changed.
    /// </summary>
    public MySQLInstance Instance { get; private set; }
  }
}