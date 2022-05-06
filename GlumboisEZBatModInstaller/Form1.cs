using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using  MaterialSkin;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO.Compression;
using System.Timers;
using FileDownloader;

namespace GlumboisEZBatModInstaller
{
  public partial class Form1 : MaterialForm
  {

    private string _PCBSPath = "";
    private CompressUncompress _compressUncompress = new CompressUncompress();
    private bool _debug;

    public Form1()
    {
      InitializeComponent();

      var materialSkinManager = MaterialSkinManager.Instance;
      materialSkinManager.AddFormToManage(this);
      materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
      materialSkinManager.ColorScheme = new ColorScheme(Primary.Orange800, Primary.Orange800, Primary.Orange800,
        Accent.Green700, TextShade.WHITE);
    }

    private bool CheckForCorrectFolder()
    {
      if (!File.Exists(_PCBSPath + @"\PCBS.exe"))
      {
        MessageBox.Show("PCBS.exe not found in the selected folder.\nPlease select the correct folder.", "PCBS.exe not found",
          MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
      }
      return true;
    }

   //Cheks if unitypatcher dir exists in pcbs folder
    private bool CheckUnityPatcher()
    {
      if (Directory.Exists(_PCBSPath + "\\unitypatcher"))
      {
        return true;
      }
      else
      {
        return false;
      }
    }
    
    //Automatically searches for common folder from steam
    private void Form1_Load(object sender, EventArgs e)
    {
      getsettings();

      string[] possibleSteamPaths =
      {
        @"C:\Program Files (x86)\Steam\steamapps\common",
        @"C:\Program Files\Steam\steamapps\common"
      };

      foreach (string path in possibleSteamPaths)
      {
        if (Directory.Exists(path))
        {
          _PCBSPath = path;
          break;
        }
      }

      if (_PCBSPath == "")
      {
        MessageBox.Show("Auto find PCBS path failed. Please manually select the path.", "Info", MessageBoxButtons.OK,
          MessageBoxIcon.Information);
      }
      else
      {
        textBox_path.Text = _PCBSPath;
      }
    }

    //Execute all bat files
    private void ExecuteBat(string path)
    {
      string[] batFiles = Directory.GetFiles(path, "*.bat", SearchOption.AllDirectories);
      foreach (string bat in batFiles)
      {
        ProcessStartInfo psi = new ProcessStartInfo();
        psi.FileName = bat;
        psi.WorkingDirectory = path;
        psi.UseShellExecute = true;
        Process p = Process.Start(psi);
        p.WaitForExit();
      }
    }
    
    //Looks if a file in the _PCBSPath contains </table> delete it
    private void DeleteFiles()
    {
      string[] files = Directory.GetFiles(_PCBSPath, "*.xml", SearchOption.TopDirectoryOnly);
      foreach (string file in files)
      {
        string text = File.ReadAllText(file);
        if (text.Contains("</table>"))
        {
          File.Delete(file);
        }
      }
      string[] files2 = Directory.GetFiles(_PCBSPath, "*.txt", SearchOption.TopDirectoryOnly);
      foreach (string file in files2)
      {
        string text = File.ReadAllText(file);
        if (text.Contains("</table>"))
        {
          File.Delete(file);
        }
      }
      string[] files3 = Directory.GetFiles(_PCBSPath, "*.bat", SearchOption.TopDirectoryOnly);
      foreach (string file in files3)
      {
        string text = File.ReadAllText(file);
        if (text.Contains("unitypatcher"))
        {
          File.Delete(file);
        }
      }
    }

    //Moves all txt and xml files in "Glumboi" folder and sub dirs to a parametered folder
    private void MoveFiles(string path)
    {
      string[] files = Directory.GetFiles(path, "*.xml", SearchOption.AllDirectories);
      foreach (string file in files)
      {
        File.Copy(file, Path.Combine(_PCBSPath, Path.GetFileName(file)),true);
      }

      files = Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories);
      foreach (string file in files)
      {
        File.Copy(file, Path.Combine(_PCBSPath, Path.GetFileName(file)),true);
      }
    }

    //Merges commands of bat files without the pause line or @echo off line
    //into one bat and executes it
    private void ExecuteBatMerge(string path)
    {
      
      string[] batFiles = Directory.GetFiles(_PCBSPath + @"\Glumboi", "*.bat", SearchOption.AllDirectories);
      string[] batFilesMerged = new string[batFiles.Length];
      int i = 0;
      foreach (string bat in batFiles)
      {
        string[] lines = File.ReadAllLines(bat);
        foreach (string line in lines)
        {
          if (line.Contains("pause") || line.Contains("@echo off"))
          {
            continue;
          }
          batFilesMerged[i] += line + "\n";
        }
        i++;
      }
      File.WriteAllLines(path + "\\merged.bat", batFilesMerged);
      ProcessStartInfo psi = new ProcessStartInfo();
      psi.FileName = path + "\\merged.bat";
      psi.WindowStyle = ProcessWindowStyle.Hidden;
      psi.WorkingDirectory = path;
      psi.UseShellExecute = true;
      try
      {
        Process p = Process.Start(psi);
        MessageBox.Show("Installation started please wait until it finished!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        p.WaitForExit();
        File.Delete(path + "\\merged.bat");
        MessageBox.Show("Installation finished!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      catch (Exception e)
      {
        MessageBox.Show("Installation failed!\n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }


    //Merges commands of bat files without the pause line or @echo off line but with one @echo off and pause at the end which says that it finished
    //into one bat and executes it
    private void ExecuteMergedBatNoPauseWithEnd(string path)
    {
      if(File.Exists(path + @"\merged.bat"))
      {
        File.Delete(path + @"\merged.bat");
      }
      
      if (string.IsNullOrWhiteSpace(_PCBSPath))
      {
        MessageBox.Show("Please select the PCBS folder first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      string[] batFiles = Directory.GetFiles(_PCBSPath + @"\Glumboi", "*.bat", SearchOption.AllDirectories);
      string mergedBat = "";
      foreach (string bat in batFiles)
      {
        string[] lines = File.ReadAllLines(bat);
        foreach (string line in lines)
        {
          if (line.Contains("pause") || line.Contains("@echo off"))
          {
            continue;
          }
          else
          {
            mergedBat += line + Environment.NewLine;
          }
        }
      }

      
      mergedBat += "@echo off" + Environment.NewLine + "pause";
      File.WriteAllText(path + "\\merged.bat", mergedBat);
      ProcessStartInfo psi = new ProcessStartInfo();
      psi.FileName = path + "\\merged.bat";
      psi.WorkingDirectory = path;
      psi.UseShellExecute = true;
      Process p = Process.Start(psi);
      p.WaitForExit();
    }

    private void getsettings()
    {
      _PCBSPath = Properties.Settings.Default.PCBSPath;
      _debug = Properties.Settings.Default.DebugMode;
      if (_debug)
      {
        Debug_install_CB.Checked = true;
      }
      else
      {
        Debug_install_CB.Checked = false;
      }

    }

    private void saveSettings()
    {
      Properties.Settings.Default.PCBSPath = _PCBSPath;
      Properties.Settings.Default.DebugMode = _debug;
      Properties.Settings.Default.Save();
    }

    private void button_selectPCBS_Click(object sender, EventArgs e)
    {
      SelectPCBSFolder();
    }

    private void SelectPCBSFolder()
    {
      CommonOpenFileDialog dialog = new CommonOpenFileDialog();
      dialog.IsFolderPicker = true;
      if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
      {
        _PCBSPath = dialog.FileName;
        textBox_path.Text = _PCBSPath;
      }
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      saveSettings();
    }
    
    public void installUnitypatcher(bool checkinstalled, string _pcbsfolder)
    {
      FileDownloader.FileDownloader fd = new FileDownloader.FileDownloader();

      if (!checkinstalled)
      {
        var locationofubitypatcher =
          "https://drive.google.com/file/d/1R87O0PaW1azTSF6GOzFdFjHuNy4r4Ijg/view?usp=sharing";
        fd.DownloadFileAsync(locationofubitypatcher, _pcbsfolder + @"\unitypatcher.zip");
        Thread.Sleep(5000);
        var ziplocation = @"\unitypatcher.zip";
        unzip(_pcbsfolder + ziplocation, _pcbsfolder);
      }
      else
      {
        if (Directory.Exists(_pcbsfolder + @"\unitypatcher"))
        {
          MessageBox.Show("unitypatcher is already installed!", "info", MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        }
        else
        {
          var ziplocation = @"\unitypatcher.zip";
          var locationofubitypatcher =
            "https://drive.google.com/file/d/1R87O0PaW1azTSF6GOzFdFjHuNy4r4Ijg/view?usp=sharing";
          fd.DownloadFileAsync(locationofubitypatcher, _pcbsfolder + "\\unitypatcher.zip");
          if(File.Exists(@"\unitypatcher.zip"))
          {
            File.Delete(@"\unitypatcher.zip");
          }
          fd.DownloadFileCompleted += (sender, e) =>
          {
            MessageBox.Show("unitypatcher finished downloading unzipping begins now!", "info", MessageBoxButtons.OK,
              MessageBoxIcon.Information);
            try
            {
              unzip(_pcbsfolder + ziplocation, _pcbsfolder);
            }
            catch (Exception exception)
            {
              MessageBox.Show($"Error: {exception}", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
              return;
            }
            
            MessageBox.Show("Unitypatcher finished unzipping!\nYou can now install mods!", "info", MessageBoxButtons.OK,
              MessageBoxIcon.Information);
          };
        }
      }


      void unzip(string zipPath, string extractPath)
      {
        ZipFile.ExtractToDirectory(zipPath, extractPath);
      }
    }

    private void Install_unitypatcher_Button_Click(object sender, EventArgs e)
    {
      
      DialogResult = MessageBox.Show("Are you sure you want to install unitypatcher?", "info", MessageBoxButtons.YesNo,
        MessageBoxIcon.Information);

      if (DialogResult == DialogResult.Yes)
      {
        Thread t1 = new Thread(() =>
        {
          installUnitypatcher(true, _PCBSPath);
        });
        t1.Start();
      }
    }
    
    //Checks if Glumboi folder contains files
    private bool checkIfGlumboiFolderIsEmpty()
    {
      if (Directory.GetFiles(_PCBSPath + @"\Glumboi").Length < 1 && Directory.GetDirectories(_PCBSPath + @"\Glumboi").Length < 1)
      {
        MessageBox.Show("Glumboi folder is empty!\nPlease drop you mods in this folder!\nCanceling the installation...", "info", MessageBoxButtons.OK,
          MessageBoxIcon.Information);
        return true;
      }
      else
      {
        return false;
      }
    }

    //Compresses the PCBS_Data folder 
    private void button_install_Click(object sender, EventArgs e)
    {
      try
      {
        DialogResult = MessageBox.Show("Are you sure you want to install the mods?", "info", MessageBoxButtons.YesNo,
          MessageBoxIcon.Information);

        if (DialogResult == DialogResult.Yes)
        {
          if (checkIfGlumboiFolderIsEmpty())
          {
            return;
          }
          if (CheckForCorrectFolder())
          {
            if (CheckUnityPatcher())
            {
              DialogResult dlg = MessageBox.Show("Do you want to backup your save files?", "info", MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);
              if (dlg == DialogResult.Yes)
              {
                if(File.Exists(_PCBSPath + @"\Saves.zip"))
                {
                  File.Delete(_PCBSPath + @"\Saves.zip");
                }
                _compressUncompress.Zip(_PCBSPath + @"\Saves", _PCBSPath + @"\Saves.zip");
                MessageBox.Show("Saves backed up!", "info", MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
              }

              KillPCBSTask();
              
              MoveFilesTask(_PCBSPath + @"\Glumboi");

              if (_debug)
              {
                MergeTask(_PCBSPath);
              }
              else
              {
                MergeTask2(_PCBSPath);
              }
            }
            else
            {
              MessageBox.Show("Unitypatcher is not installed!\nPlease install unitypatcher first!", "info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          }
        }
      }
      catch (Exception exception)
      {
        //Checks if exception contains Glumboi
        if (exception.Message.Contains("Glumboi"))
        {
          Directory.CreateDirectory(_PCBSPath + @"\Glumboi");
          MessageBox.Show("Glumboi folder is not available!\nFolder got auto created drop your mods into it!\nCanceling the installation...", "info", MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        }
      }
    }

    private async void MergeTask(string path)
    {
      await Task.Run(() =>
      {
        ExecuteMergedBatNoPauseWithEnd(path);
        DeleteFiles();
      });
    }
    
    private async void MergeTask2(string path)
    {
      await Task.Run(() =>
      {
        ExecuteBatMerge(path);
        DeleteFiles();
      });
    }

    private async void MoveFilesTask(string path)
    {
      await Task.Run(() =>
      {
        MoveFiles(path);
      });
    }

    private async void KillPCBSTask()
    {
      await Task.Run(() =>
      {
        //Checks if PCBS.exe is running and closes it
        if (Process.GetProcessesByName("PCBS").Length > 0)
        {
          Process.GetProcessesByName("PCBS")[0].Kill();
          MessageBox.Show("PCBS.exe got closed so the install can begin!", "info", MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        }
      });
    }

    private void Restore_Save_Files_Click(object sender, EventArgs e)
    {
      DialogResult = MessageBox.Show("Do you want to restore your saves?", "info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

      if (DialogResult == DialogResult.Yes)
      {
        _compressUncompress.Unzip(_PCBSPath + @"\Saves.zip", _PCBSPath + @"\Saves");
        MessageBox.Show("Done restoring saves!", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
    }

    private void timer_updatepath_Elapsed(object sender, ElapsedEventArgs e)
    {
      _PCBSPath = textBox_path.Text;
      if (!string.IsNullOrWhiteSpace(_PCBSPath))
      {
        if (!Directory.Exists(_PCBSPath + @"\Glumboi")) //if the install folder does not exist
        {
          Directory.CreateDirectory(_PCBSPath + @"\Glumboi"); //create it
        }
      }
    }

    private void Debug_install_CB_CheckedChanged(object sender, EventArgs e)
    {
      if (Debug_install_CB.Checked)
      {
        _debug = true;
      }
      else
      {
        _debug = false;
      }
    }

    private void Fix_Corrupted_Saves_Button_Click(object sender, EventArgs e)
    {
      DialogResult = MessageBox.Show("Are you sure?\nThis will delete ALL current saves!", "info",
        MessageBoxButtons.YesNo, MessageBoxIcon.Information);
      if (DialogResult == DialogResult.Yes)
      {
        //Deletes the folders and files of the save folder of PCBS
        Directory.Delete(_PCBSPath + @"\Saves", true);
        Directory.CreateDirectory(_PCBSPath + @"\Saves");
      }
    }
  }
}
