using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllatmenhelyiNyilvantarto
{
    internal class PDFGenerator
    {
        public static void PDF(string regisztraciosSzam, string orokbefogadoNev, string lakcim, string email, string faj, string allatNev, string chipszam, string datum)
        {
            string fajlnev = $"{regisztraciosSzam}_örökbefogadási_szerződés.pdf";

            string text = $@"                                   ÖRÖKBEFOGADÁSI SZERZŐDÉS

        Az örökbefogadó
        Neve : {orokbefogadoNev}
        Lakcíme: {lakcim}
        Email címe: {email}
                          
        Az örökbefogadott állat:
        Faja: {faj}
        Neve: {allatNev}
        Chipszáma: {chipszam}
                          
    Az örökbefogadó a fent nevezett kutyát az alábbi feltételekkel fogadja örökbe az Képzeletbeli Állat - és Természetvédő Egyesület 1111 Budapest Sosemvolt u.1 (továbbá örökbeadó) kutyamenhelyéről: 

    1.A fent nevezett kutyát az örökbefogadó semmilyen körülmények között nem adhatja tovább, senkinek, nem altathatja el, nem tenyésztheti, nem szaporíthatja.Az ivartalanítást állatorvossal elvégezteti, közterületre csak felügyelettel, pórázzal engedheti.A kutya eltűnéséről az örökbeadót 24 órán belül értesíteni köteles!
    2.Az örökbefogadó vállalja, az előírt egészségügyi kötelezettségeket / védőoltás, parazitamentesítés stb./ valamint azt, hogy az állat megbetegedése esetén haladéktalanul állatorvoshoz fordul. A kutyáról megfelelően fog gondoskodni.
    3.Az örökbefogadó beleegyezik, hogy az Egyesület megbízottja felkeresse és ellenőrizze a rábízott állat tartási körülményeit. Elfogadja, hogy amennyiben a kutyát az örökbefogadó nem megfelelően tartja / pl.láncra kötve, kennelben, tűző napon, árnyék, víz nélkül, élelem nélkül /, elhanyagolja, rosszul bánik vele, az örökbeadónak joga van a kutyát visszavenni feltétel és ellenszolgáltatás nélkül; valamint amennyiben állatkínzást vagy törvénytelenséget tapasztal, úgy Az állatok védelméről és kíméletéről szóló 1998.évi XXVIII.törvény értelmében a szakhatóságoknál feljelentést tenni.
    4.A felek három hét próbaidőt kötnek ki. Amennyiben a kutya nem fogadja el új helyét, nem felel meg az elvártaknak, az örökbeadó vállalja visszavételét.A későbbiekben az örökbefogadó valamilyen oknál fogva a kutyát tovább tartani nem tudja, erről értesíteni köteles az örökbeadót, hogy a kutya sorsát, és jövőjét együtt oldják meg.
            
    A felek aláírásukkal kinyilatkoztatják a szerződés valamennyi pontjával való teljes egyetértésüket.A fenti szerződés két, egymással szó szerint megegyező példányban készült.
           
    Budapest, {datum}
           
            
    Aláírás:..................";


            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();

            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Times New Roman", 10, XFontStyle.Regular);
            XTextFormatter tf = new XTextFormatter(gfx);
            XRect rect = new XRect(0, 0, page.Width, page.Height);


            //tf.Alignment = XParagraphAlignment.Left;

            tf.DrawString(text, font, XBrushes.Black, rect, XStringFormats.TopLeft);


            document.Save(fajlnev);
        }
    }
}
