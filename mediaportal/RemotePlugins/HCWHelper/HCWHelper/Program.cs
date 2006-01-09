#region Copyright (C) 2005-2006 Team MediaPortal - Author: mPod

/* 
 *	Copyright (C) 2005-2006 Team MediaPortal - Author: mPod
 *	http://www.team-mediaportal.com
 *
 *  This Program is free software; you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation; either version 2, or (at your option)
 *  any later version.
 *   
 *  This Program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 *  GNU General Public License for more details.
 *   
 *  You should have received a copy of the GNU General Public License
 *  along with GNU Make; see the file COPYING.  If not, write to
 *  the Free Software Foundation, 675 Mass Ave, Cambridge, MA 02139, USA. 
 *  http://www.gnu.org/copyleft/gpl.html
 *
 */

#endregion

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using MediaPortal.GUI.Library;

namespace MediaPortal.InputDevices.HCWHelper
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      try
      {
        Log.Write("HCW Helper: Starting up");
        Thread.CurrentThread.Priority = ThreadPriority.Highest;

        if ((Process.GetProcessesByName("HCWHelper").Length == 1) &&
          ((Process.GetProcessesByName("MediaPortal").Length > 0) ||
          (Process.GetProcessesByName("MediaPortal.vshost").Length > 0)))
        {
          System.Windows.Forms.Application.EnableVisualStyles();
          System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
          Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;
          System.Windows.Forms.Application.Run(new HCWHelper());
        }
        else
          if (Process.GetProcessesByName("HCWHelper").Length != 1)
            Log.Write("HCW Helper: HCWHelper already running - exiting");
          else
            Log.Write("HCW Helper: MediaPortal not running - exiting");
      }
      catch (Exception ex)
      {
        Log.Write("HCW Helper: Main: {0}", ex.Message);
      }
    }
  }
}