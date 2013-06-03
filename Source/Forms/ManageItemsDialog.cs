﻿//
// Copyright (c) 2012-2013, Oracle and/or its affiliates. All rights reserved.
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
  using System.Drawing;
  using System.Windows.Forms;
  using MySql.Notifier.Properties;
  using MySQL.Utility;
  using MySQL.Utility.Forms;

  /// <summary>
  /// Dialog window where users manage the monitored local and remote services and MySQL instances.
  /// </summary>
  public partial class ManageItemsDialog : MachineAwareForm
  {
    /// <summary>
    /// The service or instance object selected by the user from the corresponding list view.
    /// </summary>
    private object _selectedItem;

    /// <summary>
    /// Initializes a new instance of the <see cref="ManageItemsDialog"/> class.
    /// </summary>
    /// <param name="instancesList">List of <see cref="MySQLInstance"/> objects.</param>
    /// <param name="machineslist">List of <see cref="Machine"/> objects.</param>
    public ManageItemsDialog(MySQLInstancesList instancesList, MachinesList machineslist)
    {
      InitializeComponent();
      InstancesList = instancesList;
      machinesList = machineslist;
      RefreshServicesAndInstancesListViews();
      SetDialogControlsAvailability();
    }

    /// <summary>
    /// Specifies the monitored item type.
    /// </summary>
    public enum MonitoredItemType : int
    {
      /// <summary>
      /// Local or remote Windows service.
      /// </summary>
      Service = 0,

      /// <summary>
      /// MySQL server instance.
      /// </summary>
      MySqlInstance = 1,

      /// <summary>
      /// Default value.
      /// </summary>
      None = -1
    }

    /// <summary>
    /// Gets an object representing a list of <see cref="MySQLInstance"/> objects used to monitor MySQL Server instances.
    /// </summary>
    public MySQLInstancesList InstancesList { get; private set; }

    /// <summary>
    /// Event delegate method fired when the <see cref="AddButton"/> button is clicked.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="e">Event arguments.</param>
    private void AddButton_Click(object sender, EventArgs e)
    {
      Point screenPoint = AddButton.PointToScreen(new Point(AddButton.Left, AddButton.Bottom));
      if (screenPoint.Y + AddButtonContextMenuStrip.Size.Height > Screen.PrimaryScreen.WorkingArea.Height)
      {
        AddButtonContextMenuStrip.Show(AddButton, new Point(0, -AddButtonContextMenuStrip.Size.Height));
      }
      else
      {
        AddButtonContextMenuStrip.Show(AddButton, new Point(0, AddButton.Height));
      }
    }

    /// <summary>
    /// Adds an instance to the list of instances.
    /// </summary>
    /// <param name="instance">Instance to add.</param>
    /// <param name="setPage">Flag indicating if the Instances tab must be focused.</param>
    private void AddInstance(MySQLInstance instance, bool setPage)
    {
      ListViewItem newItem = new ListViewItem(instance.HostIdentifier);
      newItem.Tag = instance;
      newItem.SubItems.Add(instance.WorkbenchConnection.DriverType.ToString());
      newItem.SubItems.Add(instance.ConnectionStatusText);
      MonitoredInstancesListView.Items.Add(newItem);

      if (setPage)
      {
        ItemsTabControl.SelectedIndex = 1;
        newItem.Selected = true;
      }
    }

    /// <summary>
    /// Adds a service to the list of services.
    /// </summary>
    /// <param name="service">Service to add.</param>
    /// <param name="machine">Machine containing the service.</param>
    /// <param name="setPage">Flag indicating if the Services tab must be focused.</param>
    private void AddService(MySQLService service, Machine machine, bool setPage)
    {
      if (service == null)
      {
        return;
      }

      if (service.Host == null)
      {
        service.Host = machine;
        service.SetServiceParameters();
      }

      ListViewItem newItem = new ListViewItem(service.DisplayName);
      newItem.Tag = service;
      newItem.SubItems.Add(machine.Name);
      newItem.SubItems.Add(service.Status.ToString());
      MonitoredServicesListView.Items.Add(newItem);

      if (setPage)
      {
        ItemsTabControl.SelectedIndex = 0;
        newItem.Selected = true;
      }
    }

    /// <summary>
    /// Event delegate method fired when the <see cref="DeleteButton"/> button is clicked.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="e">Event arguments.</param>
    private void DeleteButton_Click(object sender, EventArgs e)
    {
      if (_selectedItem == null)
      {
        return;
      }

      if (_selectedItem is MySQLService)
      {
        MySQLService selectedService = _selectedItem as MySQLService;
        Machine machine = machinesList.GetMachineById(selectedService.Host.MachineId);
        machine.ChangeService(selectedService, ChangeType.RemoveByUser);
        MonitoredServicesListView.Items.RemoveAt(MonitoredServicesListView.SelectedIndices[0]);
      }
      else if (_selectedItem is MySQLInstance)
      {
        MySQLInstance selectedInstance = _selectedItem as MySQLInstance;
        if (InstancesList.Remove(selectedInstance))
        {
          MonitoredInstancesListView.Items.RemoveAt(MonitoredInstancesListView.SelectedIndices[0]);
        }
      }
    }

    /// <summary>
    /// Event delegate method fired when the <see cref="InstanceMonitorIntervalNumericUpDown"/> value changes.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="e">Event arguments.</param>
    private void InstanceMonitorIntervalNumericUpDown_ValueChanged(object sender, EventArgs e)
    {
      if (_selectedItem == null || !(_selectedItem is MySQLInstance))
      {
        return;
      }

      MySQLInstance selectedInstance = _selectedItem as MySQLInstance;
      selectedInstance.MonitoringInterval = (uint)InstanceMonitorIntervalNumericUpDown.Value;
    }

    /// <summary>
    /// Event delegate method fired when the <see cref="InstanceMonitorIntervalUOMComboBox"/> selected index changes.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="e">Event arguments.</param>
    private void InstanceMonitorIntervalUOMComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (_selectedItem == null || !(_selectedItem is MySQLInstance))
      {
        return;
      }

      MySQLInstance selectedInstance = _selectedItem as MySQLInstance;
      selectedInstance.MonitoringIntervalUnitOfMeasure = (TimeUtilities.IntervalUnitOfMeasure)InstanceMonitorIntervalUOMComboBox.SelectedIndex;
    }

    /// <summary>
    /// Event delegate method fired when the <see cref="ItemsTabControl"/> selected index changes.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="e">Event arguments.</param>
    private void ItemsTabControl_SelectedIndexChanged(object sender, EventArgs e)
    {
      switch (ItemsTabControl.SelectedIndex)
      {
        case 0:
          //// Services tab page
          MonitoredServicesListView_SelectedIndexChanged(MonitoredServicesListView, EventArgs.Empty);
          break;

        case 1:
          //// Instances tab page
          MonitoredInstancesListView_SelectedIndexChanged(MonitoredInstancesListView, EventArgs.Empty);
          break;

        default:
          _selectedItem = null;
          SetDialogControlsAvailability();
          break;
      }
    }

    /// <summary>
    /// Event delegate method fired when the <see cref="MonitoredInstancesListView"/> selected index changes.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="e">Event arguments.</param>
    private void MonitoredInstancesListView_SelectedIndexChanged(object sender, EventArgs e)
    {
      _selectedItem = MonitoredInstancesListView.SelectedItems.Count > 0 ? MonitoredInstancesListView.SelectedItems[0].Tag : null;
      SetDialogControlsAvailability();
    }

    /// <summary>
    /// Event delegate method fired when the <see cref="MonitoredServicesListView"/> selected index changes.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="e">Event arguments.</param>
    private void MonitoredServicesListView_SelectedIndexChanged(object sender, EventArgs e)
    {
      _selectedItem = MonitoredServicesListView.SelectedItems.Count > 0 ? MonitoredServicesListView.SelectedItems[0].Tag : null;
      SetDialogControlsAvailability();
    }

    /// <summary>
    /// Event delegate method fired when the <see cref="MySQLInstanceToolStripMenuItem"/> context menu item is clicked.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="e">Event arguments.</param>
    private void MySQLInstanceToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (var monitorInstancesDialog = new MonitorMySQLServerInstancesDialog(machinesList, InstancesList))
      {
        if (monitorInstancesDialog.ShowDialog() == DialogResult.OK)
        {
          MySqlWorkbenchConnection selectedConnection = monitorInstancesDialog.SelectedWorkbenchConnection;
          if (selectedConnection != null)
          {
            bool connectionAlreadyInInstance = false;
            MySQLInstance newInstance = null;

            //// If the selected connection exists for an already monitored instance but it is not its main connection, replace the main connection with this one.
            foreach (var instance in InstancesList)
            {
              if (instance.RelatedConnections.Exists(conn => conn.Id == selectedConnection.Id) && instance.WorkbenchConnection.Id != selectedConnection.Id)
              {
                instance.WorkbenchConnection = selectedConnection;
                connectionAlreadyInInstance = true;
                foreach (ListViewItem lvi in MonitoredInstancesListView.Items)
                {
                  MySQLInstance existingInstance = lvi.Tag as MySQLInstance;
                  if (existingInstance == instance)
                  {
                    lvi.Text = instance.HostIdentifier;
                    lvi.SubItems[0].Text = instance.WorkbenchConnection.DriverType.ToString();
                    lvi.SubItems[1].Text = instance.ConnectionStatusText;
                    break;
                  }
                }
                break;
              }
            }

            if (!connectionAlreadyInInstance)
            {
              newInstance = new MySQLInstance(selectedConnection);
              InstancesList.Add(newInstance);
              AddInstance(newInstance, true);
              InstancesList.SaveToFile();
            }
          }
        }
      }
    }

    /// <summary>
    /// Event delegate method fired when the <see cref="NotifyOnStatusChangeCheckBox"/> checked status changes.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="e">Event arguments.</param>
    private void NotifyOnStatusChangeCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      if (_selectedItem == null)
      {
        return;
      }

      if (_selectedItem is MySQLService)
      {
        MySQLService selectedService = _selectedItem as MySQLService;
        selectedService.NotifyOnStatusChange = NotifyOnStatusChangeCheckBox.Checked;
      }
      else if (_selectedItem is MySQLInstance)
      {
        MySQLInstance selectedInstance = _selectedItem as MySQLInstance;
        selectedInstance.MonitorAndNotifyStatus = NotifyOnStatusChangeCheckBox.Checked;
      }
    }

    /// <summary>
    /// Refreshes the contents of the services and instances list view controls.
    /// </summary>
    private void RefreshServicesAndInstancesListViews()
    {
      //// Set cursor to waiting, stop painting of list views to avoid flickering and clear their items.
      Cursor.Current = Cursors.WaitCursor;
      MonitoredServicesListView.BeginUpdate();
      MonitoredInstancesListView.BeginUpdate();
      MonitoredServicesListView.Items.Clear();
      MonitoredInstancesListView.Items.Clear();

      //// Add monitored services.
      foreach (Machine machine in machinesList.Machines)
      {
        foreach (MySQLService service in machine.Services)
        {
          AddService(service, machine, false);
        }
      }

      //// Add monitored instances.
      foreach (var instance in InstancesList)
      {
        AddInstance(instance, false);
      }

      //// Select automatically the first itemText or disable controls if no items exist.
      ListView pageListView = ItemsTabControl.SelectedIndex == 0 ? MonitoredServicesListView : MonitoredInstancesListView;
      if (pageListView.Items.Count > 0)
      {
        pageListView.Items[0].Selected = true;
      }
      else
      {
        pageListView.SelectedItems.Clear();
      }

      MonitoredServicesListView.EndUpdate();
      MonitoredInstancesListView.EndUpdate();

      //// Revert cursor back to normal and paint changes in list.
      Cursor.Current = Cursors.Default;
    }

    /// <summary>
    /// Event delegate method fired when the <see cref="ServiceToolStripMenuItem"/> context menu item is clicked.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="e">Event arguments.</param>
    private void ServiceToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (AddServiceDialog dialog = new AddServiceDialog(machinesList))
      {
        if (dialog.ShowDialog() == DialogResult.OK)
        {
          if (dialog.newMachine != null && dialog.ServicesToAdd != null && dialog.ServicesToAdd.Count > 0)
          {
            newMachine = machinesList.GetMachineById(dialog.newMachine.MachineId);
            if (newMachine == null)
            {
              machinesList.ChangeMachine(dialog.newMachine, ChangeType.AddByUser);
              newMachine = dialog.newMachine;
            }

            foreach (MySQLService service in dialog.ServicesToAdd)
            {
              if (newMachine.ContainsService(service))
              {
                InfoDialog.ShowWarningDialog(Resources.WarningText, Resources.ServiceAlreadyInListWarningText);
              }
              else
              {
                newMachine.ChangeService(service, ChangeType.AddByUser);
                AddService(service, newMachine, true);
              }
            }
          }
        }
        if (dialog.HasChanges)
        {
          RefreshServicesAndInstancesListViews();
        }
      }
    }

    /// <summary>
    /// Sets the availability of controls related to services or instances based on the selected item.
    /// </summary>
    private void SetDialogControlsAvailability()
    {
      DeleteButton.Enabled = _selectedItem != null;
      NotifyOnStatusChangeCheckBox.Enabled = DeleteButton.Enabled;
      UpdateTrayIconCheckBox.Enabled = DeleteButton.Enabled;

      if (_selectedItem == null)
      {
        NotifyOnStatusChangeCheckBox.Checked = false;
        UpdateTrayIconCheckBox.Checked = false;
        InstanceMonitorIntervalNumericUpDown.Value = 0;
        InstanceMonitorIntervalNumericUpDown.Enabled = false;
        InstanceMonitorIntervalUOMComboBox.Text = string.Empty;
        InstanceMonitorIntervalUOMComboBox.Enabled = false;
      }
      else if (_selectedItem is MySQLService)
      {
        MySQLService service = _selectedItem as MySQLService;
        NotifyOnStatusChangeCheckBox.Checked = service.NotifyOnStatusChange;
        UpdateTrayIconCheckBox.Checked = service.UpdateTrayIconOnStatusChange;
        InstanceMonitorIntervalNumericUpDown.Value = 0;
        InstanceMonitorIntervalNumericUpDown.Enabled = false;
        InstanceMonitorIntervalUOMComboBox.Text = string.Empty;
        InstanceMonitorIntervalUOMComboBox.Enabled = false;
      }
      else if (_selectedItem is MySQLInstance)
      {
        MySQLInstance instance = _selectedItem as MySQLInstance;
        NotifyOnStatusChangeCheckBox.Checked = instance.MonitorAndNotifyStatus;
        UpdateTrayIconCheckBox.Checked = instance.UpdateTrayIconOnStatusChange;
        InstanceMonitorIntervalNumericUpDown.Enabled = true;
        InstanceMonitorIntervalNumericUpDown.Value = instance.MonitoringInterval;
        InstanceMonitorIntervalUOMComboBox.Enabled = true;
        InstanceMonitorIntervalUOMComboBox.SelectedIndex = (int)instance.MonitoringIntervalUnitOfMeasure;
      }
    }

    /// <summary>
    /// Event delegate method fired when the <see cref="UpdateTrayIconCheckBox"/> checked status changes.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="e">Event arguments.</param>
    private void UpdateTrayIconCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      if (_selectedItem == null)
      {
        return;
      }

      if (_selectedItem is MySQLService)
      {
        MySQLService selectedService = _selectedItem as MySQLService;
        selectedService.UpdateTrayIconOnStatusChange = UpdateTrayIconCheckBox.Checked;
      }
      else if (_selectedItem is MySQLInstance)
      {
        MySQLInstance selectedInstance = _selectedItem as MySQLInstance;
        selectedInstance.UpdateTrayIconOnStatusChange = UpdateTrayIconCheckBox.Checked;
      }
    }
  }
}