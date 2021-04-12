using Autofac;
using Bank.Bll;
using Bank.Dal;

namespace Bank.DesktopClient.Util
{
    public class AutofacConfig
    {
        public static IContainer ConfigureContainer()
        {
            // получаем экземпляр контейнера
            var builder = new ContainerBuilder();

            // регистрируем контроллер в текущей сборке
            //builder.RegisterControllers(typeof(Bank.DesktopClient).Assembly);

            // регистрируем споставление типов
            builder.RegisterType<Rate>().As<IRate>();

            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();
            return container;
            // установка сопоставителя зависимостей
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
