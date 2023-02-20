using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VIN_LIB;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckLengthVin_True()
        {
            string vin = "01234567890123456";
            Assert.IsFalse(Class1.CheckVIN(vin));
        }

        [TestMethod]
        public void CheckLengthVin_False()
        {
            string vin = "1";
            Assert.IsFalse(Class1.CheckVIN(vin));
        }

        [TestMethod]
        public void CheckLetters_True()
        {
            string vin = "ASDASDASDASASDASD";
            Assert.IsTrue(Class1.CheckVIN(vin));
        }

        [TestMethod]
        public void CheckLetters_Fasle()
        {
            string vin = "asdasdasdasdassad";
            Assert.IsTrue(Class1.CheckVIN(vin));
        }

        [TestMethod]
        public void CheckCountry_True()
        {
            string vin = "A2V8L2W2OQ1KD5CRT";
            string except = "Африка";
            string actual = Class1.GetVINCountry(vin);
            Assert.AreEqual(except, actual);
        }

        [TestMethod]
        public void CheckCountry_False()
        {
            string vin = "Z2V8L2W2OQ1KD5CRT";
            string except = "Океания";
            string actual = Class1.GetVINCountry(vin);
            Assert.AreNotEqual(except, actual);
        }

        [TestMethod]
        public void CheckCountry_returnString_True()
        {
            string vin = "Z2V8L2W2OQ1KD5CRT";
            Assert.IsInstanceOfType(Class1.GetVINCountry(vin), typeof(string));
        }

        [TestMethod]
        public void CheckCountry_returnString_False()
        {
            string vin = null;
            Assert.IsNotInstanceOfType(Class1.GetVINCountry(vin), typeof(string));
        }

        [TestMethod]
        public void CheckVIN_returnBool_True()
        {
            string vin = "A2V8L2W2OQ1KD5CRT";
            Assert.IsInstanceOfType(Class1.CheckVIN(vin), typeof(bool));
        }

        [TestMethod]
        public void CheckCountry_returnNull_True()
        {
            string vin = "-2V8L2W2OQ1KD5CRT";
            Assert.IsNull(Class1.GetVINCountry(vin));
        }


        //========Сложный уровень========///

        [TestMethod]
        public void CheckVIN_nullValue()
        {
            string vin = null;
            Assert.ThrowsException<AssertFailedException>(() => Assert.ThrowsException<SystemException>(() => Class1.CheckVIN(vin)));
        }

        [TestMethod]
        public void CheckCountry_nullValue()
        {
            string vin = null;
            Assert.ThrowsException<AssertFailedException>(() => Assert.ThrowsException<SystemException>(() => Class1.GetVINCountry(vin)));
        }

        [TestMethod]
        public void CheckVIN_incorrectSymbols()
        {
            string vin = "-2V8L2W2OQ1KD5CRT";
            Assert.ThrowsException<AssertFailedException>(() => Assert.ThrowsException<SystemException>(() => Class1.CheckVIN(vin)));
        }

        [TestMethod]
        public void CheckCountry_incorrectSymbols()
        {
            string vin = "-2V8L2W2OQ1K/5CRT";
            Assert.ThrowsException<AssertFailedException>(() => Assert.ThrowsException<SystemException>(() => Class1.GetVINCountry(vin)));
        }

        [TestMethod]
        public void GetVINCountry_incorrectSymbol()
        {
            string vin = "*";
            Assert.ThrowsException<AssertFailedException>(() => Assert.ThrowsException<SystemException>(() => Class1.GetVINCountry(vin)));
        }
    }
}
