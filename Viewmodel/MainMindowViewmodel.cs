using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ArkServerConfigEditor.Annotations;
using ArkServerConfigEditor.Model;

namespace ArkServerConfigEditor.Viewmodel
{
    public class MainMindowViewmodel : INotifyPropertyChanged
    {
        private readonly string firstRow;
        public readonly string IniPath;
        public MainMindowViewmodel()
        {
            List<string> t = null;
            IniPath = @"C:\Steamcmd\steamapps\common\ARK Survival Evolved Dedicated Server\ShooterGame\Saved\Config\WindowsServer\Game.ini";
            try
            {
                t = File.ReadAllLines(IniPath).ToList();
            }
            catch (Exception e)
            {
                MessageBox.Show("ReadError");
                throw;
            }

            foreach (string s in t)
            {
                if (!s.Contains("="))
                {
                    firstRow = s;
                    continue;
                }

                List<string> strings = s.Split("=").ToList();
                SettingList.Add(new Setting { SettingName = strings[0], SettingValue = strings[1] });
            }
        }

        private ObservableCollection<Setting> settingList = new ObservableCollection<Setting>();

        public ObservableCollection<Setting> SettingList
        {
            get => settingList;

            set
            {
                if (Equals(settingList, value))
                {
                    return;
                }

                settingList = value;
                this.OnPropertyChanged(nameof(settingList));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
