using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tekla.Structures.Drawing;
using Tekla.Structures.Model;
using Tekla.Structures.Dialog;
using Tekla.Structures.Model.UI;
using Tekla.Structures.Geometry3d;
using Point = Tekla.Structures.Geometry3d.Point;
using View = Tekla.Structures.Model.UI.View;

namespace _2021
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var hand = new DrawingHandler();
            var q = hand.GetDrawingObjectSelector();

            var drawing = hand.GetActiveDrawing();

            var all = q.GetSelected();
            while (all.MoveNext())
            {
                var straight = all.Current  as WeldMark;
                var b = straight.GetAxisAlignedBoundingBox();
                //var s = straight.GetObjects();
                //foreach (var item in s)
                //{
                //        //item 为其中每一个dimension的属性，可以获取对应的值
                //}
                //var tag = view.Attributes.TagsAttributes.TagA5;
                //var tagt = tag.TagContent;
                //var conlement = new ContainerElement();
                //conlement.Frame.Type = FrameTypes.Circle;
                //conlement.Frame.Color = DrawingColors.Blue;
                //TextElement text = new TextElement("AAAAA");
                //conlement.Add(text);
                //tagt.Add(conlement);
                //view.Modify();
                //drawing.CommitChanges();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var model = new Model();
            Picker picker = new Picker();
            var bolt = picker.PickObjects(Picker.PickObjectsEnum.PICK_N_OBJECTS);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Model model = new Model();
            AABB aabb = new AABB(new Point(-1000, -1000, -1000), new Point(1000, 1000,1000));
            ModelViewEnumerator ViewEnum = ViewHandler.GetAllViews();
            while (ViewEnum.MoveNext())
            {
                var view = ViewEnum.Current;
                Tekla.Structures.Model.UI.ViewHandler.RedrawView(view);
                view.WorkArea = aabb;
                view.Modify();
                model.CommitChanges();
           
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DrawingHandler drawingHandler = new DrawingHandler();
            GADrawing drawing = drawingHandler.GetActiveDrawing() as GADrawing;
            var b = drawingHandler.GetDrawingObjectSelector().GetSelected();
            while (b.MoveNext())
            {
                var mar = b.Current;
                var a=mar.GetType().ToString();
            }

        }
    }
}
