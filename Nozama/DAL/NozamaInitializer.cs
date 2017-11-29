using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Nozama.Models;

namespace Nozama.DAL
{
    public class NozamaInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<NozamaContext>
    {
        protected override void Seed(NozamaContext context)
        { 

            //load products
            var products = new List<Product>
            {
                new Product() { ProductID = 1, ProductType=ProductType.Computer,Description="Apple 13\" MacBook Pro, Retina Display, 2.3GHz Intel Core i5 Dual Core, 8GB RAM, 128GB SSD, Silver, MPXR2LL/A (Newest Version)",Price=Convert.ToDecimal(1149.00), Image = "macbook_silver.jpg"},
                new Product() { ProductType=ProductType.Computer,Description="Apple 15\" MacBook Pro, Retina, Touch Bar, 2.9GHz Intel Core i7 Quad Core, 16GB RAM, 512GB SSD, Space Gray, MPTT2LL/A (Newest Version)",Price=Convert.ToDecimal(2599.00), Image = "macbook_space_gray.jpg"},
                new Product() { ProductType=ProductType.Tablet,Description="Apple iPad Pro Tablet (32GB, Wi-Fi, 9.7\") Gray(Certified Refurbished)",Price=Convert.ToDecimal(395.00), Image = "iPad.jpg"},
                new Product() { ProductType=ProductType.Accessory,Description="OtterBox COMMUTER SERIES Case for iPhone X (ONLY) - Standard Packaging - BLACK",Price=Convert.ToDecimal(35.96), Image = "otterbox_commuter.jpg"},
                new Product() { ProductType=ProductType.Accessory,Description="OtterBox DEFENDER SERIES Case for iPhone X (ONLY) - Retail Packaging - BIG SUR (PALE BEIGE/CORSAIR)",Price=Convert.ToDecimal(31.59), Image = "otterbox_defender.jpg"},
                new Product() { ProductType=ProductType.Computer,Description="Dell XPS 15 XPS9550-0000SLV 15.6-Inch Traditional Laptop (Machined aluminum display back and base in silver)",Price=Convert.ToDecimal(1099.99), Image = "dell_xps.jpg"},
                new Product() { ProductType=ProductType.CellPhone,Description="Samsung Galaxy Note8 (US Version) Factory Unlocked Phone - 6.3\" Screen - 64GB - Orchid Gray (U.S. Warranty)",Price=Convert.ToDecimal(859.99), Image = "samsung_galaxy.jpg"},
                new Product() { ProductType=ProductType.CellPhone,Description="Samsung Galaxy Note 8 SM-N950F/DS Factory Unlocked Phone - 6.3\" Screen - 64GB - International Version - (Midnight Black)",Price=Convert.ToDecimal(879.00), Image = "samsung_galaxy.jpg"},
                new Product() { ProductType=ProductType.Accessory,Description="Wireless Charger Car Windshield AGOZ 360° Rotating Mount Holder Cradle For Samsung Galaxy Note 8",Price=Convert.ToDecimal(23.95), Image = "charger.jpg"},
                new Product() { ProductType=ProductType.Accessory,Description="ESR iPad 2017 iPad 9.7 inch Case, Lightweight Smart Case Trifold Microfiber Lining, Hard Back Cover for Apple iPad 9.7-inch,Black",Price=Convert.ToDecimal(12.99), Image = "ipad_case.jpg"},
                new Product() { ProductType=ProductType.Accessory,Description="iPad 2 Case, iPad 3 Case, iPad 4 Case, AiSMei Rotating Stand Case Cover with Wake Up/Sleep For Apple iPad 2, iPad 3, iPad 4 ",Price=Convert.ToDecimal(10.99), Image = "ipad_case_mint_green.jpg"},
                new Product() { ProductType=ProductType.Accessory,Description="Tomtoc Drop-proof Laptop Sleeve for 13 - 13.3 Inch MacBook Air | MacBook Pro Retina Late 2012 - Early 2016 | 12.9 Inch iPad Pro, 360° Protective Chromebook Tablet Case, Spill-Resistant, Gray",Price=Convert.ToDecimal(16.99), Image = "macbook_sleeve.jpg"},
                new Product() { ProductType=ProductType.Accessory,Description="Cell Phone Case Cover For Iphone X,Matoen Thermal Sensor Physical Discoloration Softphone Case",Price=Convert.ToDecimal(1.98), Image = "iPhoneX_case_thermal.jpg"},
                new Product() { ProductType=ProductType.Tablet,Description="Microsoft Surface Pro 4 (128 GB, 4 GB RAM, Intel Core i5)",Price=Convert.ToDecimal(759.92), Image = "surface.jpg"},
                new Product() { ProductType=ProductType.Accessory,Description="Laptop Case,Tinkle ONE Slim Lightweight Laptop Shoulder Bag Cover for 14 Inch Laptop,Tablet,Macbook,Notebook (Blue)",Price=Convert.ToDecimal(23.99), Image = "laptop_case_blue.jpg"},
                new Product() { ProductType=ProductType.Computer,Description="Acer Aspire E 15 E5-575-33BM 15.6-Inch FHD Notebook (Intel Core i3-7100U 7th Generation , 4GB DDR4, 1TB 5400RPM HD, Intel HD Graphics 620, Windows 10 Home), Obsidian Black",Price=Convert.ToDecimal(357.99), Image = "acer_aspire.jpg"},
                new Product() { ProductType=ProductType.CellPhone,Description="Apple iPhone X, Fully Unlocked 5.8\", 64 GB - Silver",Price=Convert.ToDecimal(1354.99), Image = "iphoneX_silver.jpg"},
                new Product() { ProductType=ProductType.CellPhone,Description="Apple iPhone X, GSM Unlocked 5.8\", 256 GB - Space Gray",Price=Convert.ToDecimal(1525.00), Image = "iphoneX_space_gray.jpg"},
                new Product() { ProductType=ProductType.Computer,Description="Dell XPS 15 - 9560 Intel Core i7-7700HQ X4 2.8GHz 16GB 512GB SSD 15.6\" Win10, Silver",Price=Convert.ToDecimal(1699.99), Image = "dell_xps.jpg"},
                new Product() { ProductType=ProductType.Accessory,Description="FreeBiz 18.4 Inches Laptop Backpack Fits up to 18 Inch Gaming Laptops for Dell, Asus, Msi,Hp (Black)",Price=Convert.ToDecimal(55.99), Image = "backpack.jpg"},
                new Product() { ProductType=ProductType.Tablet,Description="Microsoft Surface Pro (Intel Core i5, 8GB RAM, 256GB) – Newest Version",Price=Convert.ToDecimal(1139.00), Image = "suface.jpg"},
            };
            products.ForEach(s => context.Products.Add(s));
            context.SaveChanges();

            context.Carts.Create();
        }
    }
}