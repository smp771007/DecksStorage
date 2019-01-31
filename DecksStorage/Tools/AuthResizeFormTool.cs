using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecksStorage
{
    public class AuthResizeFormTool
    {
        /// <summary>
        /// 設定視窗位置
        /// </summary>
        /// <param name="form"></param>
        /// <param name="size"></param>
        /// <param name="state"></param>
        /// <param name="location"></param>
        internal static void Set(Form form, Size size, FormWindowState state, Point location)
        {
            if (size.Width == 0 || size.Height == 0)
            {
                // first start
                // optional: add default values
            }
            else
            {
                form.WindowState = state;

                // we don't want a minimized window at startup
                if (form.WindowState == FormWindowState.Minimized) form.WindowState = FormWindowState.Normal;

                form.Location = location;
                form.Size = size;
            }
        }

        /// <summary>
        /// 取得表單狀態
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        internal static FormInfo Get(Form form)
        {
            var info = new FormInfo
            {
                State = form.WindowState
            };

            if (form.WindowState == FormWindowState.Normal)
            {
                // save location and size if the state is normal
                info.Location = form.Location;
                info.Size = form.Size;
            }
            else
            {
                // save the RestoreBounds if the form is minimized or maximized!
                info.Location = form.RestoreBounds.Location;
                info.Size = form.RestoreBounds.Size;
            }

            return info;
        }

        internal class FormInfo
        {
            public FormWindowState State { get; internal set; }
            public Point Location { get; internal set; }
            public Size Size { get; internal set; }
        }
    }
}
