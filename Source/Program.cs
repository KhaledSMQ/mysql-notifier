﻿// Copyright (c) 2006-2008 MySQL AB, 2008-2009 Sun Microsystems, Inc.
//
// MySQL Connector/NET is licensed under the terms of the GPLv2
// <http://www.gnu.org/licenses/old-licenses/gpl-2.0.html>, like most 
// MySQL Connectors. There are special exceptions to the terms and 
// conditions of the GPLv2 as it is applied to this software, see the 
// FLOSS License Exception
// <http://www.mysql.com/about/legal/licensing/foss-exception.html>.
//
// This program is free software; you can redistribute it and/or modify 
// it under the terms of the GNU General Public License as published 
// by the Free Software Foundation; version 2 of the License.
//
// This program is distributed in the hope that it will be useful, but 
// WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY 
// or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License 
// for more details.
//
// You should have received a copy of the GNU General Public License along 
// with this program; if not, write to the Free Software Foundation, Inc., 
// 51 Franklin St, Fifth Floor, Boston, MA 02110-1301  USA

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySQL.Utility;
using System.Linq;

namespace MySql.TrayApp
{
  static class Program
  {

    private static int foundUpdates { get; set; }

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(params string[] args)
    {
      if (args.Length > 0)
      {
        if (args[0] == "--c") 
        {                  
          foundUpdates = MySqlInstaller.CheckForUpdates();
          if (foundUpdates > 0)
          {
            if (MessageBox.Show(string.Format("MySQL Tray Application found {0} Update(s). Press OK to Open MySQL Installer", foundUpdates), "MySQL Tray Application", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
              MySqlInstaller.LaunchInstaller();
            }
          }                       
        }
      }
      else
      {
        if (!SingleInstance.Start()) { return; }
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        try
        {
          var applicationContext = new TrayApplicationContext();
          Application.Run(applicationContext);
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.Message, "Program Terminated Unexpectedly", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        SingleInstance.Stop();
      }
    }    
  }
}
