using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ArkServerConfigEditor.Model
{
    public class Setting : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private string settingName = string.Empty;

        private string settingValue = string.Empty;

        public string SettingValue
        {
            get => settingValue;

            set
            {
                if (Equals(settingValue, value))
                {
                    return;
                }

                settingValue = value;
                this.OnPropertyChanged(nameof(SettingValue));
            }
        }
        public string SettingName
        {
            get => settingName;
          
            set
            {
                if (Equals(settingName,value))
                {
                    return;
                }

                settingName = value;
                this.OnPropertyChanged(nameof(SettingName));
            }
        }


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
