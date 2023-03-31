using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyUnitTest.APP;

namespace UdemyUnitTest.Test
{

    /*
     test metodlarını isimlendirirken önce metod ismi sonra metodun içeriği
     en son beklenen davranış yazılır;
     MethodName_StateUnderTest_ExpectedBehaviour
     örnek:IndexReturnsARedirectToIndexHomeWhenIdIsNull:
     metod ismi index
     id değeri null geldiğinde  homeindex sayfasına yönlendirme yap
     */
    public class CalculatorTest
    {
        //calculator hem test hem de test2 metodları içinde newlendiği için constructor içinde tek bir newleme yapıldı, metod içindeki newleme kaldırıldı
        public Calculator calculator { get; set; }
        public Mock<ICalculatorService> mymock { get; set; }
        public CalculatorTest()
        {
            //this.calculator = new Calculator();
            mymock = new Mock<ICalculatorService>();
            this.calculator = new Calculator(mymock.Object);
            //this.calculator = new Calculator(new CalculatorService());
            /*mymock kullanılmadan bir kalculator nesnesi oluşturularak CalculatorService'e erişim sağlandı
            bu şekilde önce calculator sınıfına giriş yapıldı ve sonra service çalıştı
            bu sürecin daha maliyetli olduğu gözlendi
             */

        }

        [Theory]
        [InlineData(0, 5, 0)]
        [InlineData(10, 0, 0)]
        public void Add_ZeroValues_ReturnZeroValue(int a, int b, int expectedTotal)
        {
            var actualTotal = calculator.add(a, b);
            Assert.Equal(expectedTotal, actualTotal);
        }

        //eğer metod parametre alıyorsa theory ve inlinedata kullanmak gerekir
        [Theory]
        [InlineData(2, 5, 7)]
        [InlineData(10, 2, 12)]
        [InlineData(102, 22, 124)]
        //public void AddTest2(int a, int b, int expectedTotal)
        public void Add_SimpleValues_ReturnTotalValue(int a, int b, int expectedTotal)
        {
            //var calculator = new Calculator();

            mymock.Setup(x => x.add(a, b)).Returns(expectedTotal);

            var actualTotal = calculator.add(a, b);
            Assert.Equal(expectedTotal, actualTotal);
            //Assert.NotEmpty(new List<string>() { "1", "2" });
            //not empty needs a collection
            //mymock.Verify(x => x.add(a, b), Times.AtMost(2));
            //once yazıldığında metod bir kez çalışırsa test başarılı demektir
        }

        [Theory]
        [InlineData(3, 5, 15)]
        public void Multip_SimpleValues_ReturnsMultipValues(int a, int b, int expectedValue)
        {
            //mymock.Setup(x => x.multip(a, b)).Returns(10);
            /*yukarıdaki satırda şunu ifade eder;y
            a ve b değerleri ne olursa olsun döncecek sonuç 10'dur
             */
            mymock.Setup(x => x.multip(a, b)).Returns(expectedValue);
            Assert.Equal(15, calculator.multip(a, b));
        }

        [Theory]
        [InlineData(0, 5)]
        public void Multip_ZeroValues_ReturnsException(int a, int b)
        {
            mymock.Setup(x => x.multip(a, b)).Throws(new Exception("a=0 olamaz"));
            //x burada ICalculatorService yerine geçer
            Exception exception = Assert.Throws<Exception>(() => calculator.multip(a, b));
            Assert.Equal("a=0 olamaz", exception.Message);
        }


        [Fact]
        //metod parametre almıyorsa fact attribute kullanılır
        //ve fact metodun bir test metodu olduğunu ifade eder
        public void AddTest()
        {
            //*************************************************************************s
            Assert.Equal<int>(2, 2);

            //*************************************************************************s

            //string deger = null;
            //Assert.NotNull(deger);

            //*************************************************************************s

            //Assert.IsAssignableFrom<IEnumerable<string>>(new List<string>());
            // Assert.IsAssignableFrom<Object>("fatih");

            //*************************************************************************s

            //girilen değer string tipindeyse true yoksa false döndürür
            //Assert.IsType<string>(2);
            //Assert.IsNotType<string>(2);

            //*************************************************************************s

            //Assert.Single<int>(new List<int>() { 1, 2, 3 });
            //*************************************************************************s
            //Assert.Single(new List<string>() { "fatih", "3" });

            //*************************************************************************s

            //Assert.InRange(10, 12, 20);
            // Assert.NotInRange(10, 12, 20);

            //*************************************************************************s

            //Assert.NotEmpty(new List<string>() { "ali" });

            //*************************************************************************s

            ////Assert.StartsWith("zpn", "0bir zpn");
            //Assert.EndsWith("zpn", "0bir zpn");

            //*************************************************************************s

            ////var regEx = "^dog";
            ////dog ile başlayan anlamına gelir
            //var regEx = "dog$";
            ////dog ile biten anlamına gelir
            //Assert.DoesNotMatch(regEx, "adog zeytin doga");

            //*************************************************************************s

            //Assert.False(5 > 12);
            //Assert.True(4.GetType() == typeof(int));


            //var names = new List<string>() {
            //    "Fatih","Emre","Hasan"
            //};

            //Assert.Contains(names, x => x == "emre");

            //*************************************************************************s

            //Assert.DoesNotContain("emre", "alpay koyuncuoğlu");
            //Assert.Contains();

            //*************************************************************************s
            ////Arrange
            ////bir değer tanımlanacak ya da nesne örneği oluşturulacak yer arrange'dır

            //int a = 5;
            //int b = 20;
            //var calculator = new Calculator();


            ////Act
            ////metodun çalıştırılacağı yer

            //var total = calculator.add(a, b);

            ////Assert
            ////assert'ün bütün metodları 2 parametre alır

            //Assert.NotEqual<int>(26, total);

        }
    }
}
