using IdApp.Nfc.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Waher.Security;

namespace IdApp.Test
{
	[TestClass]
	public class BacTests
	{
		// Testing parsing of Machine-Readable string on identity documents, in accordance with ICAO Doc 9303
		// Reference tests: �D, https://www.icao.int/publications/Documents/9303_p11_cons_en.pdf

		[TestMethod]
		public void Test_01_Parse_MRZ_TD2_9charsplus()
		{
			string Mrz = "I<UTOSTEVENSON<<PETER<JOHN<<<<<<<<<<\nD23145890<UTO3407127M95071227349<<<8";
			Assert.IsTrue(BasicAccessControl.ParseMrz(Mrz, out DocumentInformation Info));
			Assert.AreEqual("I", Info.DocumentType);
			Assert.AreEqual("UTO", Info.IssuingState);
			Assert.AreEqual("UTO", Info.Nationality);
			Assert.AreEqual(1, Info.PrimaryIdentifier.Length);
			Assert.AreEqual("STEVENSON", Info.PrimaryIdentifier[0]);
			Assert.AreEqual(2, Info.SecondaryIdentifier.Length);
			Assert.AreEqual("PETER", Info.SecondaryIdentifier[0]);
			Assert.AreEqual("JOHN", Info.SecondaryIdentifier[1]);
			Assert.AreEqual("M", Info.Gender);
			Assert.AreEqual("D23145890734", Info.DocumentNumber);
			Assert.AreEqual("340712", Info.DateOfBirth);
			Assert.AreEqual("950712", Info.ExpiryDate);
			Assert.AreEqual("D23145890734934071279507122", Info.MRZ_Information);

			string KSeed = Hashes.BinaryToString(Info.KSeed());
			Console.Out.WriteLine("KSeed: " + KSeed);

			string KEnc = Hashes.BinaryToString(Info.KEnc());
			Console.Out.WriteLine("KEnc: " + KEnc);

			string KMac = Hashes.BinaryToString(Info.KMac());
			Console.Out.WriteLine("KMac: " + KMac);
		}

		[TestMethod]
		public void Test_02_Parse_MRZ_TD2_9chars()
		{
			string Mrz = "I<UTOERIKSSON<<ANNA<MARIA<<<<<<<<<<<\nL898902C<3UTO6908061F9406236<<<<<<<8";
			Assert.IsTrue(BasicAccessControl.ParseMrz(Mrz, out DocumentInformation Info));
			Assert.AreEqual("I", Info.DocumentType);
			Assert.AreEqual("UTO", Info.IssuingState);
			Assert.AreEqual("UTO", Info.Nationality);
			Assert.AreEqual(1, Info.PrimaryIdentifier.Length);
			Assert.AreEqual("ERIKSSON", Info.PrimaryIdentifier[0]);
			Assert.AreEqual(2, Info.SecondaryIdentifier.Length);
			Assert.AreEqual("ANNA", Info.SecondaryIdentifier[0]);
			Assert.AreEqual("MARIA", Info.SecondaryIdentifier[1]);
			Assert.AreEqual("F", Info.Gender);
			Assert.AreEqual("L898902C", Info.DocumentNumber);
			Assert.AreEqual("690806", Info.DateOfBirth);
			Assert.AreEqual("940623", Info.ExpiryDate);
			Assert.AreEqual("L898902C<369080619406236", Info.MRZ_Information);

			string KSeed = Hashes.BinaryToString(Info.KSeed());
			Console.Out.WriteLine("KSeed: " + KSeed);
			Assert.AreEqual("239AB9CB282DAF66231DC5A4DF6BFBAE", KSeed.ToUpper());

			string KEnc = Hashes.BinaryToString(Info.KEnc());
			Console.Out.WriteLine("KEnc: " + KEnc);
			Assert.AreEqual("AB94FDECF2674FDFB9B391F85D7F76F2", KEnc.ToUpper());

			string KMac = Hashes.BinaryToString(Info.KMac());
			Console.Out.WriteLine("KMac: " + KMac);
			Assert.AreEqual("7962D9ECE03D1ACD4C76089DCE131543", KMac.ToUpper());
		}

		[TestMethod]
		public void Test_03_Parse_MRZ_TD1_9charsplus()
		{
			string Mrz = "I<UTOD23145890<7349<<<<<<<<<<<\n3407127M9507122UTO<<<<<<<<<<<2\nSTEVENSON<<PETER<JOHN<<<<<<<<<";
			Assert.IsTrue(BasicAccessControl.ParseMrz(Mrz, out DocumentInformation Info));
			Assert.AreEqual("I", Info.DocumentType);
			Assert.AreEqual("UTO", Info.IssuingState);
			Assert.AreEqual("UTO", Info.Nationality);
			Assert.AreEqual(1, Info.PrimaryIdentifier.Length);
			Assert.AreEqual("STEVENSON", Info.PrimaryIdentifier[0]);
			Assert.AreEqual(2, Info.SecondaryIdentifier.Length);
			Assert.AreEqual("PETER", Info.SecondaryIdentifier[0]);
			Assert.AreEqual("JOHN", Info.SecondaryIdentifier[1]);
			Assert.AreEqual("M", Info.Gender);
			Assert.AreEqual("D23145890734", Info.DocumentNumber);
			Assert.AreEqual("340712", Info.DateOfBirth);
			Assert.AreEqual("950712", Info.ExpiryDate);
			Assert.AreEqual("D23145890734934071279507122", Info.MRZ_Information);

			string KSeed = Hashes.BinaryToString(Info.KSeed());
			Console.Out.WriteLine("KSeed: " + KSeed);

			string KEnc = Hashes.BinaryToString(Info.KEnc());
			Console.Out.WriteLine("KEnc: " + KEnc);

			string KMac = Hashes.BinaryToString(Info.KMac());
			Console.Out.WriteLine("KMac: " + KMac);
		}

		[TestMethod]
		public void Test_04_Parse_MRZ_TD1_9chars()
		{
			string Mrz = "I<UTOL898902C<3<<<<<<<<<<<<<<<\n6908061F9406236UTO<<<<<<<<<<<1\nERIKSSON<<ANNA<MARIA<<<<<<<<<<";
			Assert.IsTrue(BasicAccessControl.ParseMrz(Mrz, out DocumentInformation Info));
			Assert.AreEqual("I", Info.DocumentType);
			Assert.AreEqual("UTO", Info.IssuingState);
			Assert.AreEqual("UTO", Info.Nationality);
			Assert.AreEqual(1, Info.PrimaryIdentifier.Length);
			Assert.AreEqual("ERIKSSON", Info.PrimaryIdentifier[0]);
			Assert.AreEqual(2, Info.SecondaryIdentifier.Length);
			Assert.AreEqual("ANNA", Info.SecondaryIdentifier[0]);
			Assert.AreEqual("MARIA", Info.SecondaryIdentifier[1]);
			Assert.AreEqual("F", Info.Gender);
			Assert.AreEqual("L898902C", Info.DocumentNumber);
			Assert.AreEqual("690806", Info.DateOfBirth);
			Assert.AreEqual("940623", Info.ExpiryDate);
			Assert.AreEqual("L898902C<369080619406236", Info.MRZ_Information);

			string KSeed = Hashes.BinaryToString(Info.KSeed());
			Console.Out.WriteLine("KSeed: " + KSeed);
			Assert.AreEqual("239AB9CB282DAF66231DC5A4DF6BFBAE", KSeed.ToUpper());

			string KEnc = Hashes.BinaryToString(Info.KEnc());
			Console.Out.WriteLine("KEnc: " + KEnc);
			Assert.AreEqual("AB94FDECF2674FDFB9B391F85D7F76F2", KEnc.ToUpper());

			string KMac = Hashes.BinaryToString(Info.KMac());
			Console.Out.WriteLine("KMac: " + KMac);
			Assert.AreEqual("7962D9ECE03D1ACD4C76089DCE131543", KMac.ToUpper());
		}

		[TestMethod]
		public void Test_05_Parse_MRZ()
		{
			// �3.1, ICAO 9303-3, https://www.icao.int/publications/Documents/9303_p3_cons_en.pdf

			string Mrz = "P<UTOERIKSSON<<ANNA<MARIA<<<<<<<<<<<<<<<<<<<\nL898902C36UTO7408122F1204159ZE184226B<<<<<10";
			Assert.IsTrue(BasicAccessControl.ParseMrz(Mrz, out _));
		}

		[TestMethod]
		public void Test_06_Parse_MRZ()
		{
			// �B, ICAO 9303-5, https://www.icao.int/publications/Documents/9303_p5_cons_en.pdf

			string Mrz = "I<UTOD231458907<<<<<<<<<<<<<<<\n7408122F1204159UTO<<<<<<<<<<<6\nERIKSSON<<ANNA<MARIA<<<<<<<<<<";
			Assert.IsTrue(BasicAccessControl.ParseMrz(Mrz, out _));
		}

		[TestMethod]
		public void Test_07_Parse_MRZ()
		{
			// �B, ICAO 9303-6, https://www.icao.int/publications/Documents/9303_p6_cons_en.pdf

			string Mrz = "I<UTOERIKSSON<<ANNA<MARIA<<<<<<<<<<<\nD231458907UTO7408122F1204159<<<<<<<6";
			Assert.IsTrue(BasicAccessControl.ParseMrz(Mrz, out _));
		}

		[TestMethod]
		public void Test_08_BAC_ChallengeResponse()
		{
			byte[] Challenge = Hashes.StringToBinary("4608F91988702212");
			byte[] Rnd1 = Hashes.StringToBinary("781723860C06C226");
			byte[] Rnd2 = Hashes.StringToBinary("0B795240CB7049B01C19B33E32804F0B");
			byte[] KEnc = Hashes.StringToBinary("AB94FDECF2674FDFB9B391F85D7F76F2");
			byte[] KMac = Hashes.StringToBinary("7962D9ECE03D1ACD4C76089DCE131543");

			byte[] Response = BasicAccessControl.CalcChallengeResponse(Challenge, Rnd1, Rnd2, KEnc, KMac);

			Assert.AreEqual("72C29C2371CC9BDB65B779B8E8D37B29ECC154AA56A8799FAE2F498F76ED92F25F1448EEA8AD90A7",
				Hashes.BinaryToString(Response).ToUpper());
		}

		[TestMethod]
		public void Test_09_BAC_ChallengeResponse()
		{
			// Ref: https://sourceforge.net/p/jmrtd/discussion/580232/thread/1131f402/

			DocumentInformation Info = new DocumentInformation()
			{
				MRZ_Information = "GF043591<586012072309062"
			};

			byte[] KEnc = Info.KEnc();
			Assert.AreEqual("BA43433BF47AAEF875234FDF3208206D", Hashes.BinaryToString(KEnc).ToUpper());

			byte[] KMac = Info.KMac();
			Assert.AreEqual("EA6445CD622CEAECBF7C9B7CB020B95D", Hashes.BinaryToString(KMac).ToUpper());

			byte[] Challenge = Hashes.StringToBinary("8EAF826F89F1E525");
			byte[] Rnd1 = Hashes.StringToBinary("23E85A993A9AC5B4");
			byte[] Rnd2 = Hashes.StringToBinary("75DC87E50C8EF30047D0B5325E83204D");

			byte[] Response = BasicAccessControl.CalcChallengeResponse(Challenge, Rnd1, Rnd2, KEnc, KMac);

			Assert.AreEqual("4782B1700DD4F60373DA6632FCD1AB1E500D46FA11DEBDF9B88C39FCA7FDF8DBBE51F41D52D4B879",
				Hashes.BinaryToString(Response).ToUpper());
		}
	}
}
