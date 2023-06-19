using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Unit_Testing.Test
{
    [TestClass]
    public class WeightCalcTest
    {
        public TestContext testContext { get; set; }

        [ClassInitialize]
        public static void myClassInitialize(TestContext testContext)
        {
            testContext.WriteLine("ClassInitialize");
        }

        [ClassCleanup]
        public static void myClassCleanup()
        {

        }

        [TestInitialize]
        public void myTestInitialize()
        {

        }
        [TestCleanup]
        public void myTestCleanup()
        {

        }


        [TestMethod]
        [Description("write description")]
        [Owner("noor assaf")]
        [Priority(1)]
        [TestCategory(" getweightCategory")]
        public void getweight_SexeIsM_And_Height_180_Return_72_5()
        {
            //Arang
            WeightCalc sut = new WeightCalc
            {
                sexe = 'm',
                height = 180
            };
            //Act
            double actual = sut.getweight();
            double expected = 72.5;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        [Description("write description")]
        [Owner("noor assaf")]
        [Priority(1)]
        [TestCategory(" getweightCategory")]
        public void getweight_SexeIsW_And_Height_180_Return_65()
        {
            //Arang
            WeightCalc sut = new WeightCalc
            {
                sexe = 'w',
                height = 180
            };
            //Act
            double actual = sut.getweight();
            double expected = 65;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("write description")]
        [Owner("noor assaf")]
        [Priority(1)]
        [TestCategory(" getweightCategory")]
        public void getweight_Sexebad_And_Height_180_throwExceotion()
        {
            //Arang
            WeightCalc sut = new WeightCalc
            {
                sexe = 'r',
                height = 180
            };
            //Act
            double actual = sut.getweight();
            double expected = 0;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("write description")]
        [Owner("noor assaf")]
        [Priority(2)]
        [TestCategory(" AssertCategory")]
        public void Assert_Test()
        {
            // Assert.AreEqual(100, 90 + 10);
            // Assert.AreNotEqual(100, 90 + 10);
            //****************************************
            //WeightCalc calc1 = new WeightCalc();
            //WeightCalc calc = calc1;
            //Assert.AreSame(calc1, calc);
            //Assert.AreNotSame(calc1, calc);
            //****************************************
            //WeightCalc calc = new WeightCalc();
            //Assert.IsInstanceOfType(calc, typeof(WeightCalc));
            //Assert.IsNotInstanceOfType(calc, typeof(WeightCalc));
            //Assert.IsNotNull(calc);
            //Assert.IsNull(calc);
            //****************************************
            //Assert.IsTrue(100 == 10);
            Assert.IsFalse(100 == 10);

        }
        [TestMethod]
        [Description("write description")]
        [Owner("noor assaf")]
        [Priority(2)]
        [TestCategory("AssertCategory")]
        public void StringAssert_Test()
        {
            string name = "noor";
            name.Should().Contain("oo");
            //StringAssert.Contains(name, "oo");
            //StringAssert.EndsWith(name, "or");
            //StringAssert.StartsWith(name, "or");

        }
        [TestMethod]
        [Description("write description")]
        [Owner("noor assaf")]
        [Priority(2)]
        [TestCategory("AssertCategory")]
        [Ignore]
        public void colectionAssert_Test()
        {
            List<string> names = new List<string>() { "noor", "assaf", "maram", "sara" };
            List<string> name1 = new List<string>() { "noor", "assaf", "maram", "sara" };
            CollectionAssert.AllItemsAreNotNull(names);
            CollectionAssert.Contains(names, "maram");
            CollectionAssert.AreEquivalent(name1, names);
            CollectionAssert.AllItemsAreInstancesOfType(name1, typeof(string));
            CollectionAssert.IsSubsetOf(names, names);
        }
        [TestMethod]
        [Description("write description")]
        [Owner("noor assaf")]
        [Priority(3)]
        [TestCategory("AssertCategory")]
        [Timeout(3000)]
        public void fluentAssertion_Test()
        {
            string name = "assaf";
            name.Should().StartWith("a").And.EndWith("f");
            name.Should().HaveLength(5);
            //name.Should().BeNullOrEmpty();
            int num = 10;
            num.Should().BeGreaterThan(8);
            num.Should().BeLessOrEqualTo(10);
            List<string> name1 = new List<string>() { "noor", "assaf", "maram", "sara" };
            name1.Should().HaveCount(4);
        }
        [TestMethod]
        public void getweightsFromDataSource_withGoodInput_Return_Correct_Result()
        {
            WeightCalc weightCalc = new WeightCalc(new FakeWeight());

            List<double> actual = weightCalc.getweightsFromDataSource();
            double[] expected = { 62.5, 62.75, 74 };
            // CollectionAssert.AreEqual(expected, actual);
            // actual.Should().Equal(expected);
            actual.Should().BeEquivalentTo(expected);
        }
        [TestMethod]
        public void getWeightFromDataSouurceUsing_Moq()
        {
            List<WeightCalc> weightCalcs = new List<WeightCalc>()
            {
                   new WeightCalc {height=175,sexe='w'},
                   new WeightCalc {height=167,sexe='m'},
            };
            Mock<IWeightRepo> repo= new Mock<IWeightRepo>();
            repo.Setup(w => w.getWeights()).Returns(weightCalcs);
            WeightCalc calc=new WeightCalc(repo.Object);
            var actual = calc.getweightsFromDataSource();
            double[] expected = {62.5,62.75 };
            actual.Should().Equal(expected);
        }
        [TestMethod]
        public void getWeightFromDataSouurceUsing_FAkeITEasy()
        {
            List<WeightCalc> weightCalcs = new List<WeightCalc>()
            {
                   new WeightCalc {height=175,sexe='w'},
                   new WeightCalc {height=167,sexe='m'},
            };
            IWeightRepo repo = A.Fake<IWeightRepo>();
            //repo.Setup(w => w.getWeights()).Returns(weightCalcs);
            A.CallTo(() => repo.getWeights()).Returns(weightCalcs);
            WeightCalc calc = new WeightCalc(repo);
            var actual = calc.getweightsFromDataSource();
            double[] expected = { 62.5, 62.75 };
            actual.Should().Equal(expected);
        }
        [DataTestMethod]//one test mor data
        [DataRow(175,'w',62.5)]
        [DataRow(167,'m',62.75)]
        [DataRow(182,'m',74)]
        public void WorkingWith_dataDrivenTest(double height,char sex,double expexted)
        {
            WeightCalc weightCalc= new WeightCalc { height=height,sexe=sex};
            var actual = weightCalc.getweight();
            actual.Should().Be(expexted);
        }
        public static List<object[]> TestCase()
        {
            return new List<object[]> { 
                new object[] { 175, 'w', 62.5 } ,
                new object[] { 167, 'm', 62.75 } ,
                new object[] { 182, 'm', 74 } 
            };
        }
        [DataTestMethod]
        [DynamicData(nameof(TestCase),DynamicDataSourceType.Method)]
        public void workingWith_DynamicData(double height, char sex, double expexted)
        {
            WeightCalc weightCalc = new WeightCalc { height = height, sexe = sex };
            var actual = weightCalc.getweight();
            actual.Should().Be(expexted);
        }
        //TDD
        [TestMethod]
        public void vaildate_with_badSex_return_false()
        {
            WeightCalc weight = new WeightCalc { sexe = 'r' };
            bool actual = weight.vaildate();
            actual.Should().BeFalse();
        }
    }
}