using System;
using UnityEngine;

namespace RichTextExtention
{
	public static class RichTextExtention
	{
		public static string Coloring(this string text,string color)
		{
			string output = "";
			output += "<color=" + color + ">";
			output += text;
			output += "</color>";
			return output;
		}

		public static string Bold(this string text)
		{
			string output = "";
			output += "<b>";
			output += text;
			output += "</b>";
			return output;
		}
		public static string Italic(this string text)
		{
			string output = "";
			output += "<i>";
			output += text;
			output += "</i>";
			return output;
		}
		public static string FromStyle(this string text,RichString rs){

			string output = "";
			if (rs.bold) {
				output += "<b>";
			}
			if (rs.italic) {
				output += "<i>";
			}
			if (rs.colored) {
				output += "<color=" + rs.Color + ">";
			}

			output += text;

			if (rs.colored) {
				output += "</color>";
			}
			if (rs.italic) {
				output += "</i>";
			}
			if (rs.bold) {
				output += "</b>";
			}
			return output;
			
		}
	}
}
