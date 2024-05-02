using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace TurkishDraughts;
public class RoundPictureBox : PictureBox
{
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        // Create a GraphicsPath to draw the image in a round shape
        using (GraphicsPath path = new GraphicsPath())
        {
            path.AddEllipse(new Rectangle(0, 0, 74, 74));
            this.Region = new Region(path);
        }
    }
}