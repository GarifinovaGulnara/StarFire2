using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using StarFire2.db;

namespace StarFire2
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static StarFireEntities starFireEntities = new StarFireEntities();
        public static Authorization user;
    }
}
