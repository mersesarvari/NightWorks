using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNJXL9_HFT_2021221.Data;
using ZNJXL9_HFT_2021221.Logic;
using ZNJXL9_HFT_2021221.Models;
using ZNJXL9_HFT_2021221.Repository;

namespace ZNJXL9_HFT_2021221.Test
{
    [TestFixture]
    public class Tester
    {
        [TestFixture]
        public class TestWithMock
        {
            #region MOQ-Setup
            //Érdemes lenne normál teszteket írni... 
            UserLogic cl;
            RoleLogic bl;
            PostLogic wl;
            public TestWithMock()
            {
                Mock<IUserRepository> mockStarshipRepository =
                    new Mock<IUserRepository>();

                Role fakeBrand = new Role()
                {
                    Id = 0,
                    Name = "ST1"
                };
                mockStarshipRepository.Setup((t) => t.Create(It.IsAny<User>()));
                mockStarshipRepository.Setup((t) => t.ReadAll()).Returns(
                    new List<User>()
                    {
                    new User()
                    {
                        Model = "ModelName",
                        RoleId = 0,
                        WeaponId = 1,
                        BasePrice = 300,
                        Id = 1
                    },
                    new User()
                    {
                        Model = "ModelName2",
                        RoleId = 0,
                        WeaponId = 11,
                        BasePrice = 100,
                        Id = 2
                    }
                    }.AsQueryable());
                cl = new UserLogic(mockStarshipRepository.Object);

                //Brand
                Mock<IRoleRepository> mockBrandRepository =
                    new Mock<IRoleRepository>();
                mockBrandRepository.Setup((t) => t.Create(It.IsAny<Role>()));
                mockBrandRepository.Setup((t) => t.ReadAll()).Returns(
                    new List<Role>()
                    {
                    new Role(){ Name="Testbrand1",Id=1},
                    new Role(){ Name="Testbrand2",Id=2},
                    }.AsQueryable());
                bl = new RoleLogic(mockBrandRepository.Object);

                Mock<IPostRepository> mockWeaponRepository =
                    new Mock<IPostRepository>();
                mockWeaponRepository.Setup((t) => t.Create(It.IsAny<Post>()));
                mockWeaponRepository.Setup((t) => t.ReadAll()).Returns(
                    new List<Post>()
                    {
                    new Post(){ Name="Testweapon1",Id=1},
                    new Post(){ Name="Testweapon2",Id=2},
                    }.AsQueryable());
                wl = new PostLogic(mockWeaponRepository.Object);
            }
            #endregion
            
            #region CREATE
            [TestCase(3000, true)]
            [TestCase(2000, true)]
            public void CreateStarshipTest(int price, bool result)
            {
                if (result)
                {
                    Assert.That(() => cl.Create(new User()
                    {
                        Model = "Astra",
                        BasePrice = price
                    }), Throws.Nothing);
                }
                else
                {
                    Assert.That(() => cl.Create(new User()
                    {
                        Model = "Astra",
                        BasePrice = price
                    }), Throws.Exception);
                }
            }
            [Test]
            public void CreateBrandTest()
            {
                Assert.That(() => bl.Create(new Role()
                {
                    Name = "BrandName1",
                    Id = 3
                }), Throws.Nothing);
            }
            [Test]
            public void CreateWeaponTest()
            {
                Assert.That(() => wl.Create(new Post()
                {
                    Name = "WeaponName1",
                    Id = 1
                }), Throws.Nothing);
            }
            #endregion
            
            #region NON-CRUD
            [Test]
            public void AVGPriceTest()
            {
                var result = cl.AVGPrice();
                Assert.That(result, Is.EqualTo(200));

            }
            [Test]
            public void AVGPriceByModelTest()
            {
                //ACT
                var result = cl.AVGPriceByModels().ToArray();

                //ASSERT
                Assert.That(result[0],
                    Is.EqualTo(new KeyValuePair<string, double>
                    ("ModelName", 300)));
            }
            [Test]
            public void MostUsedWeaponTest()
            {
                Assert.That(wl.MostUsedWeapon().Name == "Testweapon1");
            }
            [Test]
            public void GetModelAvarageTest()
            {
                Assert.That(() => cl.GetModelAverages(), Throws.Nothing);
            }
            [TestCase(1, false)]
            [TestCase(2, true),]
            public void GetTheCheapestStarShip(int id, bool r)
            {
                var result = cl.CheapestStarship();
                Assert.That((result.Id == id) == r);
            }
            [Test]
            public void MostUsedBrandTest()
            {
                Assert.That(bl.MostUsedBrand().Name == "Testbrand1");
            }
            [TestCase(1, true)]
            [TestCase(2, false)]
            public void GetTheMostExpensiveStarshipTest(int id, bool r)
            {
                var result = cl.MostExpensiveStarship();
                Assert.That((result.Id == id) == r);
            }

            #endregion
            
            #region FREE
            [Test]            
            public void GetOneStarshipTest()
            {
                Assert.That(() => cl.Read(1), Throws.Nothing);
            }
            
            [Test]
            public void GetAllStarshipTest()
            {
                Assert.That(() => cl.ReadAll(), Throws.Nothing);
            }

            [Test]
            public void GetOneBrandTest()
            {
                Assert.That(() => bl.Read(1), Throws.Nothing);
            }
            [Test]
            public void GetAllBrandTest()
            {
                Assert.That(() => bl.ReadAll(), Throws.Nothing);
            }

            
            [Test]
            public void GetOneWeaponTest()
            {
                Assert.That(() => wl.Read(1), Throws.Nothing);
            }
            [Test]
            public void GetAllWeaponTest()
            {
                Assert.That(() => wl.ReadAll(), Throws.Nothing);
            }
            #endregion

        }
    }
}
