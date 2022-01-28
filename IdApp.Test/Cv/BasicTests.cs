﻿using System;
using IdApp.Cv;
using IdApp.Cv.Basic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdApp.Test.Cv
{
	[TestClass]
	public class BasicTests
	{
		[TestMethod]
		public void Test_01_Copy()
		{
			IMatrix M = Bitmaps.FromBitmapFile("Cv\\TestData\\100_pass2-uto.jpg", 600, 600);
			Matrix<uint> M2 = M as Matrix<uint>;
			Assert.IsNotNull(M2);
			Matrix<uint> M3 = M2.Copy();
			Bitmaps.ToImageFile(M3, "Cv\\Results\\Basic\\Test_01_Copy.png");
		}

		[TestMethod]
		public void Test_02_Fill()
		{
			IMatrix M = Bitmaps.FromBitmapFile("Cv\\TestData\\100_pass2-uto.jpg", 600, 600);
			Matrix<uint> M2 = M as Matrix<uint>;
			Assert.IsNotNull(M2);
			Matrix<uint> Region = M2.Region(200, 200, M2.Width - 400, M2.Height - 400);
			Region.Fill<uint>(0xff4080c0);
			Bitmaps.ToImageFile(M2, "Cv\\Results\\Basic\\Test_02_Fill.png");
		}
	}
}
