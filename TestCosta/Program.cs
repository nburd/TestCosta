using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Windows.Forms;
using TestCosta.Model;
using TestCosta.Presenters;
using TestCosta.Views;

namespace TestCosta
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            var container = new Container();            
            Register(container);        
            
            using (AsyncScopedLifestyle.BeginScope(container))
            {
                container.GetInstance<IApplicationController>().Start();
            }
        }

        private static void Register(Container container)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            container.Register<IApplicationController, ApplicationController>();
            container.Register<IPresenterFactory, PresenterFactory>();
            container.Register<IMainView, MainForm>(Lifestyle.Scoped);
            container.Register<IEmployeeView, EmployeeForm>(Lifestyle.Scoped);
            container.Register<IDepartmentView, DepartmentForm>(Lifestyle.Scoped);
            container.Register<IDepartmentRepository, DepartmentRepository>();
            container.Register<IEmployeeRepository, EmployeeRepository>();
            container.Register<IMainPresenter, MainPresenter>();
            container.Register<IEmployeePresenter, EmployeePresenter>();
            container.Register<IDepartmentPresenter, DepartmentPresenter>();
            container.Verify();            
        }
    }
}
