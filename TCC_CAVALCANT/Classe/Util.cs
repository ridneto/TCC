using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace TCC_CAVALCENT
{
    public class Utils
{
	/// <summary>
	/// Método que formata para moeda o conteúdo de um TextBox
	/// </summary>
	/// <param name="txt">Controle a ser formatado</param>
	/// <remarks></remarks>
	public static void TextBoxMoeda(TextBox txt)
	{
		string n = string.Empty;
		double v = 0;
		try {
			n = txt.Text.Replace(",", "").Replace(".", "");
			if (n.Equals(""))
				n = "000";
			n = n.PadLeft(3, '0');
			if (n.Length > 3 & n.Substring(0, 1) == "0")
				n = n.Substring(1, n.Length - 1);
			v = Convert.ToDouble(n) / 100;
			txt.Text = string.Format("{0:N}", v);
			txt.SelectionStart = txt.Text.Length;
		} catch (Exception ex) {
			MessageBox.Show(ex.Message, "TextBoxMoeda");
		}
	}
}
}


