using Microsoft.EntityFrameworkCore;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using MyLaptopShop.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MyLaptopShop.WpfClient.ViewModels
{
    public class LaptopWindowViewModel :ObservableRecipient
    {
        public RestCollection<Laptop> Laptops { get; set; }

        private Laptop selectedLaptop;

        public Laptop SelectedLaptop
        {
            get => selectedLaptop; set
            {
                if (value != null)
                {
                    selectedLaptop = new Laptop()
                    {
                        Name = value.Name,
                        Id = value.Id,
                        BrandId = value.BrandId,
                        ReleaseYear = value.ReleaseYear,
                        BasePrice=value.BasePrice,
                        

                    };
                    OnPropertyChanged();
                    (DeleteLaptopCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateLaptopCommand { get; set; }
        public ICommand UpdateLaptopCommand { get; set; }
        public ICommand DeleteLaptopCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public LaptopWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Laptops = new RestCollection<Laptop>("http://localhost:60327/", "laptop", "hub");
                CreateLaptopCommand = new RelayCommand(() =>
                {
                    Laptops.Add(new Laptop()
                    {
                        Name = SelectedLaptop.Name,
                        BasePrice = SelectedLaptop.BasePrice,
                        BrandId = SelectedLaptop.BrandId,
                        ReleaseYear = SelectedLaptop.ReleaseYear,

                    });
                });

                DeleteLaptopCommand = new RelayCommand(() =>
                {
                    Laptops.Delete(SelectedLaptop.Id);
                },
                () =>
                {
                    return SelectedLaptop != null;
                });

                UpdateLaptopCommand = new RelayCommand(() =>
                {
                        Laptops.Update(SelectedLaptop);                  
                });
                SelectedLaptop = new Laptop();
            }
        }
    }
}
