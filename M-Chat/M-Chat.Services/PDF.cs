using System;
using System.Collections.Generic;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using M_Chat.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Globalization;

namespace M_Chat.Services
{
    public static class PDF
    {
        public static MemoryStream CrearPdf(string nombre, Respuestas respuestas, string root)
        {
            Document document = new Document();
            MemoryStream stream = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(document, stream);
            Image logo = Image.GetInstance(Path.Combine(root, "favicon.png"));
            Image Criterios = Image.GetInstance(Path.Combine(root,"criterios.png"));
            document.Open();
            logo.ScaleAbsoluteWidth(50);
            logo.ScaleAbsoluteHeight(50);
            document.Add(logo);
            document.AddTitle(new Phrase("Los Resultados Fueron").ToString());           
            document.Add(new Paragraph($"Estas son las respuestas de su hij@ {nombre}"));
            document.Add(new Paragraph($"\n 1. ¿Disfruta su hijo cuando se le balancea o se le hace saltar sobre sus rodillas? \n R:{respuestas.RespuestaId=1}"));
            document.Add(new Paragraph($"\n 2. ¿Muestra interés por otros niños o niñas? \n R:{respuestas.RespuestaId = 2}"));
            document.Add(new Paragraph($"\n 3. ¿Le gusta subirse a las cosas, como sillones, escalones, juegos del parque?\n R:{respuestas.RespuestaId = 3}"));
            document.Add(new Paragraph($"\n 4. ¿Le gusta que el adulto juegue con él o ella al “cucú-tras” (taparse los ojos y luego descubrirlos; jugar a esconderse y aparecer de repente)? \n R:{respuestas.RespuestaId = 4}"));
            document.Add(new Paragraph($"\n 5. ¿Hace juegos imaginativos, como si hablara por teléfono, como si estuviera dando de comer a una muñeca o si estuviera conduciendo un coche? \n R:{respuestas.RespuestaId = 5}"));
            document.Add(new Paragraph($"\n 6. ¿Suele señalar con el dedo para pedir algo?\n R:{respuestas.RespuestaId = 6}"));
            document.Add(new Paragraph($"\n 7. ¿Suele señalar con el dedo para indicar que algo le llama la atención?\n R:{respuestas.RespuestaId = 7}"));
            document.Add(new Paragraph($"\n 8. ¿Puede jugar adecuadamente con piezas o juguetes pequeños (por ejemplo cochecitos, muñequitos o bloques de construcción), sin únicamente chuparlos, agitarlos o tirarlos ?\n R:{respuestas.RespuestaId=8}"));
            document.Add(new Paragraph($"\n 9. ¿Suele traerle objetos para enseñárselos??\n R:{respuestas.RespuestaId=9}"));
            document.Add(new Paragraph($"\n 10. ¿Suele mirarle a los ojos durante unos segundos?\n R:{respuestas.RespuestaId=10}"));
            document.Add(new Paragraph($"\n 11. ¿Le parece demasiado sensible a ruidos poco intensos? (por ejemplo, reacciona tapándose los oídos, o le genera alguna angustia)?\n R:{respuestas.RespuestaId=11}"));
            document.Add(new Paragraph($"\n 12. ¿Sonríe al verle a usted o cuando usted le sonríe?\n R:{respuestas.RespuestaId=12}"));
            document.Add(new Paragraph($"\n 13. ¿Puede imitar o repetir gestos o acciones que usted hace? (por ejemplo, si usted hace una mueca él o ella también la hace)?\n R:{respuestas.RespuestaId=14}"));
            document.Add(new Paragraph($"\n 14. ¿Responde cuando se le llama por su nombre?\n R:{respuestas.RespuestaId=15}"));
            document.Add(new Paragraph($"\n 15. Si usted señala con el dedo un juguete al otro lado de la habitación, ¿dirige su hijo o hija la mirada hacia ese juguete ?\n R:{respuestas.RespuestaId=16}"));
            document.Add(new Paragraph($"\n 16. ¿Ha aprendido ya a caminar?\n R:{respuestas.RespuestaId=17}"));
            document.Add(new Paragraph($"\n 17. Si usted está mirando algo atentamente, ¿su hijo o hija se pone también a mirarlo ? R:{respuestas.RespuestaId=18}\n"));
            document.Add(new Paragraph($"\n 18. ¿Hace su hijo o hija movimientos raros con los dedos, por ejemplo, acercándoselos a los ojos ?\n R:{respuestas.RespuestaId=19}"));
            document.Add(new Paragraph($"\n 19. ¿Intenta que usted preste atención a las actividades que él o ella está haciendo ?\n R:{respuestas.RespuestaId = 20}"));
            document.Add(new Paragraph($"\n 20. ¿Alguna vez ha pensado que su hijo o hija podría tener sordera?\n R:{respuestas.RespuestaId=22}"));
            document.Add(new Paragraph($"\n 21. ¿Entiende su hijo o hija lo que la gente dice?\n R:{respuestas.RespuestaId=23}"));
            document.Add(new Paragraph($"\n 22. ¿Se queda a veces mirando al vacío o va de un lado al otro sin propósito? \n R:{respuestas.RespuestaId=24}"));
            document.Add(new Paragraph($"\n 23. Si su hijo o hija tiene que enfrentarse a una situación desconocida, ¿le mira primero a usted a la cara para saber cómo reaccionar ?\n R:{respuestas.RespuestaId=25}"));
            Criterios.ScaleAbsoluteHeight(400);
            Criterios.ScaleAbsoluteWidth(450);
            document.Add(Criterios);
           

            writer.CloseStream = false;
            document.Close();
            stream.Position = 0;
            return stream;
        }
    }
}
