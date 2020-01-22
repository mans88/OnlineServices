using MealServices.DataLayer;
using MealServices.DataLayer.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using OnlineServices.Common.MealServices.Enumerations;
using OnlineServices.Common.MealServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MealServices.DataLayerTests
{
    [TestClass]
    public class MealRepositoryTests
    {
        [TestMethod()]
        public void IRepositoryInsert_ShouldInsertInDb_WhenValidMealIsProvided()
        {
            var options = new DbContextOptionsBuilder<MealContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using (var memoryCtx = new MealContext(options))
            {
                //ARRANGE
                var MealToUseInTest = new MealTO
                {
                    Id = 0,
                    Name = new MultiLanguageString("Meal1EN", "Meal1FR", "Meal1NL"),
                    Ingredients = new List<IngredientTO> {
                        new IngredientTO {
                            Id = 1,
                            Name = new MultiLanguageString("Ingr1EN", "Ingr1FR", "Ingr1NL"), IsAllergen = false
                        }
                    },
                    Supplier = new SupplierTO { Name = "Fournisseur1" },
                    MealType = MealType.Sandwich
                };

                var mealRepository = new MealRepository(memoryCtx);

                //ACT
                mealRepository.Add(MealToUseInTest);
                memoryCtx.SaveChanges();

                //ASSERT
                Assert.AreEqual(1, mealRepository.GetAll().Count());
                var MealToAssert = mealRepository.GetById(1);

                Assert.AreEqual(1, MealToAssert.Id);
                Assert.AreEqual(1, MealToAssert.Ingredients.FirstOrDefault().Id);
                Assert.AreEqual("Meal1EN", MealToAssert.Name.English);
            }
        }

        [TestMethod()]
        public void IRepositoryGetByID_ShouldRetrieveMeal_WhenValidIdIsProvided()
        {
            //ARRANGE
            var options = new DbContextOptionsBuilder<MealContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using (var memoryCtx = new MealContext(options))
            {
                var MealToUseInTest = new MealTO
                {
                    Id = 0,
                    Name = new MultiLanguageString("Meal1EN", "Meal1FR", "Meal1NL"),
                    Ingredients = new List<IngredientTO> {
                        new IngredientTO {
                            Id = 1,
                            Name = new MultiLanguageString("Ingr1EN", "Ingr1FR", "Ingr1NL"), IsAllergen = false
                        }
                    },
                    Supplier = new SupplierTO { Name = "Fournisseur1" },
                    MealType = MealType.Sandwich
                };

                var mealRepository = new MealRepository(memoryCtx);

                //ACT
                mealRepository.Add(MealToUseInTest);
                memoryCtx.SaveChanges();
                var retrivedMeal = mealRepository.GetById(1);

                //ASSERT
                Assert.AreEqual(1, retrivedMeal.Id);
                Assert.AreEqual("Meal1EN", mealRepository.GetById(1).Name.English);
            }
        }

        [TestMethod()]
        public void IRepositoryGetAll_ShouldRetrieveMeals_WhenCalled()
        {
            //ASSERT
            var options = new DbContextOptionsBuilder<MealContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using (var memoryCtx = new MealContext(options))
            {
                //ARRANGE
                var MealToUseInTest1 = new MealTO
                {
                    Id = 0,
                    Name = new MultiLanguageString("Meal1EN", "Meal1FR", "Meal1NL"),
                    Ingredients = new List<IngredientTO> {
                        new IngredientTO {
                            Id = 1,
                            Name = new MultiLanguageString("Ingr1EN", "Ingr1FR", "Ingr1NL"), IsAllergen = false
                        }
                    },
                    Supplier = new SupplierTO { Name = "Fournisseur1" },
                    MealType = MealType.Sandwich
                };

                var MealToUseInTest2 = new MealTO
                {
                    Id = 0,
                    Name = new MultiLanguageString("Meal2EN", "Meal2FR", "Meal2NL"),
                    Ingredients = new List<IngredientTO> {
                        new IngredientTO {
                            Id = 2,
                            Name = new MultiLanguageString("Ingr1EN", "Ingr1FR", "Ingr1NL"), IsAllergen = false
                        }
                    },
                    Supplier = new SupplierTO { Name = "Fournisseur1" },
                    MealType = MealType.Sandwich
                };

                var mealRepository = new MealRepository(memoryCtx);

                //ACT
                mealRepository.Add(MealToUseInTest1);
                mealRepository.Add(MealToUseInTest2);
                memoryCtx.SaveChanges();

                var retrievedMeals = mealRepository.GetAll();

                Assert.AreEqual(2, retrievedMeals.Count());
                Assert.AreEqual(1, retrievedMeals.FirstOrDefault().Id);
            }
        }

        [TestMethod()]
        public void IRepositoryDeleteById_ShouldDelete_WhenValidIdIsProvided()
        {
            //ASSERT
            var options = new DbContextOptionsBuilder<MealContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using (var memoryCtx = new MealContext(options))
            {
                //ARRANGE
                var MealToUseInTest1 = new MealTO
                {
                    Id = 0,
                    Name = new MultiLanguageString("Meal1EN", "Meal1FR", "Meal1NL"),
                    Ingredients = new List<IngredientTO> {
                        new IngredientTO {
                            Id = 0,
                            Name = new MultiLanguageString("Ingr1EN", "Ingr1FR", "Ingr1NL"), IsAllergen = false
                        }
                    },
                    Supplier = new SupplierTO { Name = "Fournisseur1" },
                    MealType = MealType.Sandwich
                };

                var MealToUseInTest2 = new MealTO
                {
                    Id = 0,
                    Name = new MultiLanguageString("Meal2EN", "Meal2FR", "Meal2NL"),
                    Ingredients = new List<IngredientTO> {
                        new IngredientTO {
                            Id = 0,
                            Name = new MultiLanguageString("Ingr1EN", "Ingr1FR", "Ingr1NL"), IsAllergen = false
                        }
                    },
                    Supplier = new SupplierTO { Name = "Fournisseur1" },
                    MealType = MealType.Sandwich
                };

                var mealRepository = new MealRepository(memoryCtx);

                //ACT
                mealRepository.Add(MealToUseInTest1);
                memoryCtx.SaveChanges();
                mealRepository.Add(MealToUseInTest2);
                memoryCtx.SaveChanges();
                mealRepository.Remove(2);
                memoryCtx.SaveChanges();

                var retrievedMeals = mealRepository.GetAll();

                Assert.AreEqual(1, retrievedMeals.Count());
                Assert.IsFalse(retrievedMeals.Any(x => x.Id == 2));
            }
        }

        [TestMethod()]
        public void IRepositoryDeleteById_ShouldThrowException_WhenDeletingANonExistantMeal()
        {
            //ASSERT
            var options = new DbContextOptionsBuilder<MealContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using (var memoryCtx = new MealContext(options))
            {
                //ARRANGE
                var MealToUseInTest1 = new MealTO
                {
                    Id = 0,
                    Name = new MultiLanguageString("Meal1EN", "Meal1FR", "Meal1NL"),
                    Ingredients = new List<IngredientTO> {
                        new IngredientTO {
                            Id = 1,
                            Name = new MultiLanguageString("Ingr1EN", "Ingr1FR", "Ingr1NL"), IsAllergen = false
                        }
                    },
                    Supplier = new SupplierTO { Name = "Fournisseur1" },
                    MealType = MealType.Sandwich
                };

                var MealToUseInTest2 = new MealTO
                {
                    Id = 0,
                    Name = new MultiLanguageString("Meal2EN", "Meal2FR", "Meal2NL"),
                    Ingredients = new List<IngredientTO> {
                        new IngredientTO {
                            Id = 2,
                            Name = new MultiLanguageString("Ingr1EN", "Ingr1FR", "Ingr1NL"), IsAllergen = false
                        }
                    },
                    Supplier = new SupplierTO { Name = "Fournisseur1" },
                    MealType = MealType.Sandwich
                };

                var mealRepository = new MealRepository(memoryCtx);

                //ACT
                mealRepository.Add(MealToUseInTest1);
                mealRepository.Add(MealToUseInTest2);
                memoryCtx.SaveChanges();
                mealRepository.Remove(2);
                memoryCtx.SaveChanges();

                //ASSERT
                Assert.ThrowsException<Exception>(() => mealRepository.Remove(2));
            }
        }
        [TestMethod()]
        public void IRepositoryDeleteByTransfertObject_ShouldDelete_WhenValidTOIsProvided()
        {
            //ASSERT
            var options = new DbContextOptionsBuilder<MealContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using (var memoryCtx = new MealContext(options))
            {
                //ARRANGE
                var MealToUseInTest1 = new MealTO
                {
                    Id = 0,
                    Name = new MultiLanguageString("Meal1EN", "Meal1FR", "Meal1NL"),
                    Ingredients = new List<IngredientTO> {
                        new IngredientTO {
                            Id = 1,
                            Name = new MultiLanguageString("Ingr1EN", "Ingr1FR", "Ingr1NL"), IsAllergen = false
                        }
                    },
                    Supplier = new SupplierTO { Name = "Fournisseur1" },
                    MealType = MealType.Sandwich
                };

                var MealToUseInTest2 = new MealTO
                {
                    Id = 0,
                    Name = new MultiLanguageString("Meal2EN", "Meal2FR", "Meal2NL"),
                    Ingredients = new List<IngredientTO> {
                        new IngredientTO {
                            Id = 2,
                            Name = new MultiLanguageString("Ingr1EN", "Ingr1FR", "Ingr1NL"), IsAllergen = false
                        }
                    },
                    Supplier = new SupplierTO { Name = "Fournisseur1" },
                    MealType = MealType.Sandwich
                };

                var mealRepository = new MealRepository(memoryCtx);

                //ACT
                mealRepository.Add(MealToUseInTest1);
                mealRepository.Add(MealToUseInTest2);
                memoryCtx.SaveChanges();
                MealToUseInTest2.Id = 2;
                mealRepository.Remove(MealToUseInTest2);
                memoryCtx.SaveChanges();

                var retrievedMeals = mealRepository.GetAll();

                Assert.AreEqual(1, retrievedMeals.Count());
                Assert.IsFalse(retrievedMeals.Any(x => x.Id == 2));
            }
        }

        [TestMethod()]
        public void IRepositoryDeleteByTransfertObject_ShouldThrowException_WhenDeletingANonExistantMeal()
        {
            //ASSERT
            var options = new DbContextOptionsBuilder<MealContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using (var memoryCtx = new MealContext(options))
            {
                //ARRANGE
                var MealToUseInTest1 = new MealTO
                {
                    Id = 0,
                    Name = new MultiLanguageString("Meal1EN", "Meal1FR", "Meal1NL"),
                    Ingredients = new List<IngredientTO> {
                        new IngredientTO {
                            Id = 1,
                            Name = new MultiLanguageString("Ingr1EN", "Ingr1FR", "Ingr1NL"), IsAllergen = false
                        }
                    },
                    Supplier = new SupplierTO { Name = "Fournisseur1" },
                    MealType = MealType.Sandwich
                };

                var MealToUseInTest2 = new MealTO
                {
                    Id = 0,
                    Name = new MultiLanguageString("Meal2EN", "Meal2FR", "Meal2NL"),
                    Ingredients = new List<IngredientTO> {
                        new IngredientTO {
                            Id = 2,
                            Name = new MultiLanguageString("Ingr1EN", "Ingr1FR", "Ingr1NL"), IsAllergen = false
                        }
                    },
                    Supplier = new SupplierTO { Name = "Fournisseur1" },
                    MealType = MealType.Sandwich
                };

                var mealRepository = new MealRepository(memoryCtx);

                //ACT
                mealRepository.Add(MealToUseInTest1);
                mealRepository.Add(MealToUseInTest2);
                memoryCtx.SaveChanges();
                MealToUseInTest2.Id = 2;
                mealRepository.Remove(MealToUseInTest2);
                memoryCtx.SaveChanges();

                //ASSERT
                Assert.ThrowsException<Exception>(() => mealRepository.Remove(MealToUseInTest2));
            }
        }

        [TestMethod()]
        public void IRepositoryUpdate_ShouldUpdateInDb_WhenValidMealIsProvided()
        {
            var options = new DbContextOptionsBuilder<MealContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using (var memoryCtx = new MealContext(options))
            {
                //ARRANGE
                var MealToUseInTest = new MealTO
                {
                    Id = 1,
                    Name = new MultiLanguageString("Meal1EN", "Meal1FR", "Meal1NL"),
                    Ingredients = new List<IngredientTO> {
                        new IngredientTO {
                            Id = 2,
                            Name = new MultiLanguageString("Ingr1EN", "Ingr1FR", "Ingr1NL"), IsAllergen = false
                        }
                    },
                    Supplier = new SupplierTO { Name = "Fournisseur1" },
                    MealType = MealType.Salad
                };

                var mealRepository = new MealRepository(memoryCtx);

                //ACT
                mealRepository.Add(MealToUseInTest);
                memoryCtx.SaveChanges();
                //MealToUseInTest.Id = 1;
                MealToUseInTest.MealType = MealType.Sandwich;
                mealRepository.Update(MealToUseInTest);
                memoryCtx.SaveChanges();

                var MealToAssert = mealRepository.GetById(1);
                //ASSERT
                Assert.AreEqual(1, mealRepository.GetAll().Count());
                Assert.AreEqual(1, MealToAssert.Id);
                Assert.AreEqual(2, MealToAssert.Ingredients.FirstOrDefault().Id);
                Assert.AreEqual("Meal1EN", MealToAssert.Name.English);
                Assert.AreEqual(MealType.Sandwich, MealToAssert.MealType);
            }
        }
    }
}
