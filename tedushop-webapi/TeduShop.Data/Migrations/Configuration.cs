namespace TeduShop.Data.Migrations
{
    using Common;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TeduShop.Data.TeduShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TeduShop.Data.TeduShopDbContext context)
        {
            CreateProductCategorySample(context);
            CreateProductSample(context);
            CreateSlide(context);
            CreatePage(context);
            CreateContactDetail(context);

            CreateConfigTitle(context);
            CreateFooter(context);
            CreateUser(context);
            CreateSize(context);
            CreateColor(context);
            CreateFunction(context);
        }
        private void CreateProductSample(TeduShop.Data.TeduShopDbContext context)
        {
            if (context.Products.Count() == 0)
            {
                List<Product> listProduct = new List<Product>()
                {
                    new Product() { Name="LV721 Bộ vest nữ trẻ trung màu rêu sang chảnh",Alias="LV721-Bo-vest-nu-tay-lung-4-1",CategoryID=2,ThumbnailImage="/UploadedFiles/Products/LV721-Bo-vest-nu-tay-lung-4-1.jpg",Price=1080000,OriginalPrice=1000000,PromotionPrice=1050000,IncludedVAT=true,Warranty=12,HomeFlag=true,HotFlag=true,CreatedDate=DateTime.Now,CreatedBy="admin",Status=true },
                    new Product() { Name="LV721 Bộ vest nữ đẹp dáng tay lỡ",Alias="lv721-bo-vest-nu-dep-dang-tay-lo",CategoryID=2,ThumbnailImage="/UploadedFiles/Products/LV721-Bo-vest-nu-tay-lung-1.jpg",Price=1070000,OriginalPrice=1000000,PromotionPrice=1050000,IncludedVAT=true,Warranty=12,HomeFlag=true,HotFlag=true,CreatedDate=DateTime.Now,CreatedBy="admin",Status=true },
                    new Product() { Name="LV721 Bộ vest tay lỡ đỏ nổi bật",Alias="lv721-bo-vest-tay-lo-noi-bat",CategoryID=2,ThumbnailImage="/UploadedFiles/Products/LV721-Bo-vest-nu-tay-lung-1-2-290x417.jpg",Price=1170000,OriginalPrice=1000000,PromotionPrice=1050000,IncludedVAT=true,Warranty=12,HomeFlag=true,HotFlag=true,CreatedDate=DateTime.Now,CreatedBy="admin",Status=true },
                    new Product() { Name="LV721 Bộ vest công sở kiểu cách tân",Alias="lv721-bo-vest-cong-kieu-cach-tan",CategoryID=2,ThumbnailImage="/UploadedFiles/Products/LV721-Bo-vest-nu-tay-lung-1-3-290x417.jpg",Price=1270000,OriginalPrice=1000000,PromotionPrice=1050000,IncludedVAT=true,Warranty=12,HomeFlag=true,HotFlag=true,CreatedDate=DateTime.Now,CreatedBy="admin",Status=true },
                    new Product() { Name="LV721 Bộ vest nữ đen tay lửng",Alias="lv721-bo-vest-nu-den-tay-lung",CategoryID=2,ThumbnailImage="/UploadedFiles/Products/LV721-Bo-vest-tay-lung-1-290x417.jpg",Price=1020000,OriginalPrice=1000000,PromotionPrice=1050000,IncludedVAT=true,Warranty=12,HomeFlag=true,HotFlag=true,CreatedDate=DateTime.Now,CreatedBy="admin",Status=true },
                    new Product() { Name="MT66 Áo măng tô nữ dáng ôm đính cúc nổi",Alias="mt66-ao-mang-nu-dang-om-dinh-cuc-noi",CategoryID=2,ThumbnailImage="/UploadedFiles/Products/MT66-ao-khoac-da-dang-dai-6-290x417.jpg",Price=1090000,OriginalPrice=1000000,PromotionPrice=1050000,IncludedVAT=true,Warranty=12,HomeFlag=true,HotFlag=true,CreatedDate=DateTime.Now,CreatedBy="admin",Status=true },
                    new Product() { Name="MT66 Áo măng tô cao cấp dáng ôm",Alias="mt66-ao-mang-cao-cap-dang-om",CategoryID=2,ThumbnailImage="/UploadedFiles/Products/MT66-ao-khoac-da-dang-dai-15-290x417.jpg",Price=1020000,OriginalPrice=1000000,PromotionPrice=1050000,IncludedVAT=true,Warranty=12,HomeFlag=true,HotFlag=true,CreatedDate=DateTime.Now,CreatedBy="admin",Status=true },
                    new Product() { Name="MT66 Áo khoác dạ nữ cổ xếp",Alias="mt66-ao-khoac-da-nu-co-xep",CategoryID=2,ThumbnailImage="/UploadedFiles/Products/MT66-ao-khoac-da-dang-dai-9-290x417.jpg",Price=1020000,OriginalPrice=1000000,PromotionPrice=1050000,IncludedVAT=true,Warranty=12,HomeFlag=true,HotFlag=true,CreatedDate=DateTime.Now,CreatedBy="admin",Status=true },
                    new Product() { Name="MT66 Áo khoác dạ cao cấp dáng cúc nổi",Alias="mt66-ao-khoac-da-cao-cap-dang-cuc-noi",CategoryID=2,ThumbnailImage="/UploadedFiles/Products/MT66-ao-khoac-da-dang-dai-2-290x417.jpg",Price=1420000,OriginalPrice=1000000,PromotionPrice=1050000,IncludedVAT=true,Warranty=12,HomeFlag=true,HotFlag=true,CreatedDate=DateTime.Now,CreatedBy="admin",Status=true },
                    new Product() { Name="LV719 Bộ vest dạ cách tân trẻ trung",Alias="lv719-bo-vest-da-cach-tan-tre-trung",CategoryID=2,ThumbnailImage="/UploadedFiles/Products/LV719-bo-vest-da-9-290x417.jpg",Price=1120000,OriginalPrice=1000000,PromotionPrice=1050000,IncludedVAT=true,Warranty=12,HomeFlag=true,HotFlag=true,CreatedDate=DateTime.Now,CreatedBy="admin",Status=true },
                    new Product() { Name="LV719 Bộ vest dạ đẹp dáng áo cổ tròn",Alias="lv719-bo-vest-da-dep-dang-ao-co-tron",CategoryID=2,ThumbnailImage="/UploadedFiles/Products/LV719-bo-vest-da-3-290x417.jpg",Price=1520000,OriginalPrice=1000000,PromotionPrice=1050000,IncludedVAT=true,Warranty=12,HomeFlag=true,HotFlag=true,CreatedDate=DateTime.Now,CreatedBy="admin",Status=true },
                    new Product() { Name="MT70 Áo khoác nữ dáng gile",Alias="mt70-ao-khoac-nu-dang-gile",CategoryID=2,ThumbnailImage="/UploadedFiles/Products/MT70-Ao-khoac-gile-2-290x417.jpg",Price=1270000,OriginalPrice=1000000,PromotionPrice=1050000,IncludedVAT=true,Warranty=12,HomeFlag=true,HotFlag=true,CreatedDate=DateTime.Now,CreatedBy="admin",Status=true },
                    new Product() { Name="MT70 Áo vest nữ dáng dài kiểu gile",Alias="mt70-ao-vest-nu-dang-dai-kieu-gile",CategoryID=2,ThumbnailImage="/UploadedFiles/Products/MT70-Ao-vest-dang-dai-kieu-gile-2-290x417.jpg",Price=1460000,OriginalPrice=1000000,PromotionPrice=1050000,IncludedVAT=true,Warranty=12,HomeFlag=true,HotFlag=true,CreatedDate=DateTime.Now,CreatedBy="admin",Status=true },
                    new Product() { Name="MT70 Áo gile nữ dáng dài",Alias="mt70-ao-gile-nu-dang-dai",CategoryID=2,ThumbnailImage="/UploadedFiles/Products/MT70-ao-khoac-gile-5-290x417.jpg",Price=1600000,OriginalPrice=1000000,PromotionPrice=1050000,IncludedVAT=true,Warranty=12,HomeFlag=true,HotFlag=true,CreatedDate=DateTime.Now,CreatedBy="admin",Status=true },
                    new Product() { Name="MT61 Áo măng tô thời thượng kiểu cúc nổi",Alias="mt61-ao-mang-thoi-thuong-kieu-cuc-noi",CategoryID=2,ThumbnailImage="/UploadedFiles/Products/MT61C-ao-mang-to-da-dang-dai-2-290x417.jpg",Price=1360000,OriginalPrice=1000000,PromotionPrice=1050000,IncludedVAT=true,Warranty=12,HomeFlag=true,HotFlag=true,CreatedDate=DateTime.Now,CreatedBy="admin",Status=true },
                    new Product() { Name="MT70 Áo vest nữ dáng dài kiểu gile",Alias="mt70-ao-vest-nu-dang-dai-kieu-gile",CategoryID=2,ThumbnailImage="/UploadedFiles/Products/MT70-Ao-vest-dang-dai-kieu-gile-2-290x417.jpg",Price=1460000,OriginalPrice=1000000,PromotionPrice=1050000,IncludedVAT=true,Warranty=12,HomeFlag=true,HotFlag=true,CreatedDate=DateTime.Now,CreatedBy="admin",Status=true },

                };
                context.Products.AddRange(listProduct);
                context.SaveChanges();
            }
        }
        private void CreateFunction(TeduShopDbContext context)
        {
            if (context.Functions.Count() == 0)
            {
                context.Functions.AddRange(new List<Function>()
                {
                    new Function() {ID = "SYSTEM", Name = "Hệ thống",ParentId = null,DisplayOrder = 1,Status = true,URL = "/",IconCss = "fa-desktop"  },
                    new Function() {ID = "ROLE", Name = "Nhóm",ParentId = "SYSTEM",DisplayOrder = 1,Status = true,URL = "/main/role/index",IconCss = "fa-home"  },
                    new Function() {ID = "FUNCTION", Name = "Chức năng",ParentId = "SYSTEM",DisplayOrder = 2,Status = true,URL = "/main/function/index",IconCss = "fa-home"  },
                    new Function() {ID = "USER", Name = "Người dùng",ParentId = "SYSTEM",DisplayOrder =3,Status = true,URL = "/main/user/index",IconCss = "fa-home"  },
                    new Function() {ID = "ACTIVITY", Name = "Nhật ký",ParentId = "SYSTEM",DisplayOrder = 4,Status = true,URL = "/main/activity/index",IconCss = "fa-home"  },
                    new Function() {ID = "ERROR", Name = "Lỗi",ParentId = "SYSTEM",DisplayOrder = 5,Status = true,URL = "/main/error/index",IconCss = "fa-home"  },
                    new Function() {ID = "SETTING", Name = "Cấu hình",ParentId = "SYSTEM",DisplayOrder = 6,Status = true,URL = "/main/setting/index",IconCss = "fa-home"  },

                    new Function() {ID = "PRODUCT",Name = "Sản phẩm",ParentId = null,DisplayOrder = 2,Status = true,URL = "/",IconCss = "fa-chevron-down"  },
                    new Function() {ID = "PRODUCT_CATEGORY",Name = "Danh mục",ParentId = "PRODUCT",DisplayOrder =1,Status = true,URL = "/main/product-category/index",IconCss = "fa-chevron-down"  },
                    new Function() {ID = "PRODUCT_LIST",Name = "Sản phẩm",ParentId = "PRODUCT",DisplayOrder = 2,Status = true,URL = "/main/product/index",IconCss = "fa-chevron-down"  },
                    new Function() {ID = "ORDER",Name = "Hóa đơn",ParentId = "PRODUCT",DisplayOrder = 3,Status = true,URL = "/main/order/index",IconCss = "fa-chevron-down"  },

                    new Function() {ID = "CONTENT",Name = "Nội dung",ParentId = null,DisplayOrder = 3,Status = true,URL = "/",IconCss = "fa-table"  },
                    new Function() {ID = "POST_CATEGORY",Name = "Danh mục",ParentId = "CONTENT",DisplayOrder = 1,Status = true,URL = "/main/post-category/index",IconCss = "fa-table"  },
                    new Function() {ID = "POST",Name = "Bài viết",ParentId = "CONTENT",DisplayOrder = 2,Status = true,URL = "/main/post/index",IconCss = "fa-table"  },

                    new Function() {ID = "UTILITY",Name = "Tiện ích",ParentId = null,DisplayOrder = 4,Status = true,URL = "/",IconCss = "fa-clone"  },
                    new Function() {ID = "FOOTER",Name = "Footer",ParentId = "UTILITY",DisplayOrder = 1,Status = true,URL = "/main/footer/index",IconCss = "fa-clone"  },
                    new Function() {ID = "FEEDBACK",Name = "Phản hồi",ParentId = "UTILITY",DisplayOrder = 2,Status = true,URL = "/main/feedback/index",IconCss = "fa-clone"  },
                    new Function() {ID = "ANNOUNCEMENT",Name = "Thông báo",ParentId = "UTILITY",DisplayOrder = 3,Status = true,URL = "/main/announcement/index",IconCss = "fa-clone"  },
                    new Function() {ID = "CONTACT",Name = "Lien hệ",ParentId = "UTILITY",DisplayOrder = 4,Status = true,URL = "/main/contact/index",IconCss = "fa-clone"  },

                    new Function() {ID = "REPORT",Name = "Báo cáo",ParentId = null,DisplayOrder = 5,Status = true,URL = "/",IconCss = "fa-bar-chart-o"  },
                    new Function() {ID = "REVENUES",Name = "Báo cáo doanh thu",ParentId = "REPORT",DisplayOrder = 1,Status = true,URL = "/main/report/revenues",IconCss = "fa-bar-chart-o"  },
                    new Function() {ID = "ACCESS",Name = "Báo cáo truy cập",ParentId = "REPORT",DisplayOrder = 2,Status = true,URL = "/main/report/visitor",IconCss = "fa-bar-chart-o"  },
                    new Function() {ID = "READER",Name = "Báo cáo độc giả",ParentId = "REPORT",DisplayOrder = 3,Status = true,URL = "/main/report/reader",IconCss = "fa-bar-chart-o"  },

                });
                context.SaveChanges();
            }
        }

        private void CreateConfigTitle(TeduShopDbContext context)
        {
            if (!context.SystemConfigs.Any(x => x.Code == "HomeTitle"))
            {
                context.SystemConfigs.Add(new SystemConfig()
                {
                    Code = "HomeTitle",
                    ValueString = "Trang chủ TeduShop",
                });
            }
            if (!context.SystemConfigs.Any(x => x.Code == "HomeMetaKeyword"))
            {
                context.SystemConfigs.Add(new SystemConfig()
                {
                    Code = "HomeMetaKeyword",
                    ValueString = "Trang chủ TeduShop",
                });
            }
            if (!context.SystemConfigs.Any(x => x.Code == "HomeMetaDescription"))
            {
                context.SystemConfigs.Add(new SystemConfig()
                {
                    Code = "HomeMetaDescription",
                    ValueString = "Trang chủ TeduShop",
                });
            }
        }

        private void CreateUser(TeduShopDbContext context)
        {
            var manager = new UserManager<AppUser>(new UserStore<AppUser>(new TeduShopDbContext()));
            if (manager.Users.Count() == 0)
            {
                var roleManager = new RoleManager<AppRole>(new RoleStore<AppRole>(new TeduShopDbContext()));

                var user = new AppUser()
                {
                    UserName = "admin",
                    Email = "admin@tedu.com.vn",
                    EmailConfirmed = true,
                    BirthDay = DateTime.Now,
                    FullName = "Bach Ngoc Toan",
                    Avatar = "/assets/images/img.jpg",
                    Gender = true,
                    Status = true
                };
                if (manager.Users.Count(x => x.UserName == "admin") == 0)
                {
                    manager.Create(user, "123654$");

                    if (!roleManager.Roles.Any())
                    {
                        roleManager.Create(new AppRole { Name = "Admin", Description = "Quản trị viên" });
                        roleManager.Create(new AppRole { Name = "Member", Description = "Người dùng" });
                    }

                    var adminUser = manager.FindByName("admin");

                    manager.AddToRoles(adminUser.Id, new string[] { "Admin", "Member" });
                }
            }
        }

        private void CreateProductCategorySample(TeduShop.Data.TeduShopDbContext context)
        {
            if (context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
                {
                    new ProductCategory() { Name="Áo nam",Alias="ao-nam",Status=true },
                    new ProductCategory() { Name="Áo nữ",Alias="ao-nu",Status=true },
                    new ProductCategory() { Name="Giày nam",Alias="giay-nam",Status=true },
                    new ProductCategory() { Name="Giày nữ",Alias="giay-nu",Status=true }
                };
                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }
        }
        private void CreateSize(TeduShop.Data.TeduShopDbContext context)
        {
            if (context.Sizes.Count() == 0)
            {
                List<Size> listSize = new List<Size>()
                {
                    new Size() { Name="XXL" },
                    new Size() { Name="XL"},
                    new Size() { Name="L" },
                    new Size() { Name="M" },
                    new Size() { Name="S" },
                    new Size() { Name="XS" }
                };
                context.Sizes.AddRange(listSize);
                context.SaveChanges();
            }
        }

        private void CreateColor(TeduShop.Data.TeduShopDbContext context)
        {
            if (context.Colors.Count() == 0)
            {
                List<Color> listColor = new List<Color>()
                {
                    new Color() {Name="Đen", Code="#000000" },
                    new Color() {Name="Trắng", Code="#FFFFFF"},
                    new Color() {Name="Đỏ", Code="#ff0000" },
                    new Color() {Name="Xanh", Code="#1000ff" },
                };
                context.Colors.AddRange(listColor);
                context.SaveChanges();
            }
        }
        private void CreateFooter(TeduShopDbContext context)
        {
            if (context.Footers.Count(x => x.ID == CommonConstants.DefaultFooterId) == 0)
            {
                string content = "Footer";
                context.Footers.Add(new Footer()
                {
                    ID = CommonConstants.DefaultFooterId,
                    Content = content
                });
                context.SaveChanges();
            }
        }

        private void CreateSlide(TeduShopDbContext context)
        {
            if (context.Slides.Count() == 0)
            {
                List<Slide> listSlide = new List<Slide>()
                {
                    new Slide() {
                        Name ="Slide 1",
                        DisplayOrder =1,
                        Status =true,
                        Url ="#",
                        Image ="/Assets/client/images/bag.jpg",
                        Content =@"	<h2>FLAT 50% 0FF</h2>
                                <label>FOR ALL PURCHASE <b>VALUE</b></label>
                                <p>Lorem ipsum dolor sit amet, consectetur
                            adipisicing elit, sed do eiusmod tempor incididunt ut labore et </ p >
                        <span class=""on-get"">GET NOW</span>" },
                    new Slide() {
                        Name ="Slide 2",
                        DisplayOrder =2,
                        Status =true,
                        Url ="#",
                        Image ="/Assets/client/images/bag1.jpg",
                    Content=@"<h2>FLAT 50% 0FF</h2>
                                <label>FOR ALL PURCHASE <b>VALUE</b></label>

                                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et </ p >

                                <span class=""on-get"">GET NOW</span>"},
                };
                context.Slides.AddRange(listSlide);
                context.SaveChanges();
            }
        }

        private void CreatePage(TeduShopDbContext context)
        {
            if (context.Pages.Count() == 0)
            {
                try
                {
                    var page = new Page()
                    {
                        Name = "Giới thiệu",
                        Alias = "gioi-thieu",
                        Content = @"Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium ",
                        Status = true
                    };
                    context.Pages.Add(page);
                    context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var eve in ex.EntityValidationErrors)
                    {
                        Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation error.");
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Trace.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                        }
                    }
                }
            }
        }

        private void CreateContactDetail(TeduShopDbContext context)
        {
            if (context.ContactDetails.Count() == 0)
            {
                try
                {
                    var contactDetail = new TeduShop.Model.Models.ContactDetail()
                    {
                        Name = "Shop thời trang TEDU",
                        Address = "Ngõ 77 Xuân La",
                        Email = "tedu@gmail.com",
                        Lat = 21.0633645,
                        Lng = 105.8053274,
                        Phone = "095423233",
                        Website = "http://tedu.com.vn",
                        Other = "",
                        Status = true
                    };
                    context.ContactDetails.Add(contactDetail);
                    context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var eve in ex.EntityValidationErrors)
                    {
                        Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation error.");
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Trace.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                        }
                    }
                }
            }
        }
    }
}