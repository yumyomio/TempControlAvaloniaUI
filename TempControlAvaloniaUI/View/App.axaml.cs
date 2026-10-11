using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using System;
using System.Linq;
using TempControlAvaloniaUI.Model;

namespace TempControlAvaloniaUI.View;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        using (var db = new ClimateDbContext())
        {
            db.Database.EnsureCreated();
            var randomData = new ClimateData
            {
                Temperature = 23.4,
                Humidity = 55.2,
                Pressure = 758.5,
                TimeStamp = DateTime.Now
            };

            // Добавляем запись в таблицу
            db.ClimateDatas.Add(randomData);
            // Сохраняем изменения в файл базы данных climate.db
            db.SaveChanges();

            var allDatas= db.ClimateDatas.ToList();
        }
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow();
        }

        base.OnFrameworkInitializationCompleted();
    }
}