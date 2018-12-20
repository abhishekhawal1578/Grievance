﻿
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
namespace Griveance
{
	public class CryptIt
	{
		public static string Decrypt(string plainText0)
		{
			string passPhrase = "Pas5pr@se";
			string saltValue = "s@1tValue";
			string hashAlgorithm = "SHA1";
			int passwordIterations = 2;
			string initVector = "@1B2c3D4e5F6g7H8";
			int keySize = 0x80;
			return Decrypt(plainText0, passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize);
		}

		public static string Decrypt(string cipherText, string passPhrase, string saltValue, string hashAlgorithm, int passwordIterations, string initVector, int keySize)
		{
			byte[] bytes = Encoding.ASCII.GetBytes(initVector);
			byte[] rgbSalt = Encoding.ASCII.GetBytes(saltValue);
			byte[] buffer = Convert.FromBase64String(cipherText);
			byte[] rgbKey = new PasswordDeriveBytes(passPhrase, rgbSalt, hashAlgorithm, passwordIterations).GetBytes(keySize / 8);
			ICryptoTransform transform = new RijndaelManaged { Mode = CipherMode.CBC }.CreateDecryptor(rgbKey, bytes);
			MemoryStream stream = new MemoryStream(buffer);
			CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
			byte[] buffer5 = new byte[buffer.Length];
			int count = stream2.Read(buffer5, 0, buffer5.Length);
			stream.Close();
			stream2.Close();
			return Encoding.UTF8.GetString(buffer5, 0, count);
		}

		public static string Encrypt(string plainText0)
		{
			string passPhrase = "Pas5pr@se";
			string saltValue = "s@1tValue";
			string hashAlgorithm = "SHA1";
			int passwordIterations = 2;
			string initVector = "@1B2c3D4e5F6g7H8";
			int keySize = 0x80;
			return Encrypt(plainText0, passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize);
		}

		public static string Encrypt(string plainText, string passPhrase, string saltValue, string hashAlgorithm, int passwordIterations, string initVector, int keySize)
		{
			byte[] bytes = Encoding.ASCII.GetBytes(initVector);
			byte[] rgbSalt = Encoding.ASCII.GetBytes(saltValue);
			byte[] buffer = Encoding.UTF8.GetBytes(plainText);
			byte[] rgbKey = new PasswordDeriveBytes(passPhrase, rgbSalt, hashAlgorithm, passwordIterations).GetBytes(keySize / 8);
			ICryptoTransform transform = new RijndaelManaged { Mode = CipherMode.CBC }.CreateEncryptor(rgbKey, bytes);
			MemoryStream stream = new MemoryStream();
			CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write);
			stream2.Write(buffer, 0, buffer.Length);
			stream2.FlushFinalBlock();
			byte[] inArray = stream.ToArray();
			stream.Close();
			stream2.Close();
			return Convert.ToBase64String(inArray);
		}
	}
}

	


