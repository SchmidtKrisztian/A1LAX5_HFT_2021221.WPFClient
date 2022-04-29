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

namespace MyLaptopShop.WpfClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<Brand> Brands { get; set; }

        private Brand selectedBrand;
       
        public Brand SelectedBrand { get => selectedBrand; set 
            {
                if (value != null)
                {
                    selectedBrand = new Brand()
                    {
                        Name = value.Name,
                        Id = value.Id,
                        Headquarters = value.Headquarters,
                        FoundationYear = value.FoundationYear,
                        CEOName = value.CEOName,

                    };
                    OnPropertyChanged();
                    (DeleteBrandCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            } 
        }

        public ICommand CreateBrandCommand { get; set; }
        public ICommand UpdateBrandCommand { get; set; }
        public ICommand DeleteBrandCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Brands = new RestCollection<Brand>("http://localhost:60327/", "brand", "hub");
                CreateBrandCommand = new RelayCommand(() =>
                {
                    Brands.Add(new Brand()
                    {
                        Name = SelectedBrand.Name,
                        Headquarters = SelectedBrand.Headquarters,
                        FoundationYear = SelectedBrand.FoundationYear,
                        CEOName = SelectedBrand.CEOName,

                    });
                });

                DeleteBrandCommand = new RelayCommand(() =>
                {
                    Brands.Delete(SelectedBrand.Id);
                },
                () =>
                {
                    return SelectedBrand != null;
                });

                UpdateBrandCommand = new RelayCommand(() =>
                {
                    Brands.Update(SelectedBrand);
                });
                SelectedBrand = new Brand();
            }
        }

    }
}
