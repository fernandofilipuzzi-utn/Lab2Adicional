﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServicioEncuestas_design.BackofficeAdmin
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["UsuarioSettings"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddMinutes(3);
                HttpContext.Current.Response.Cookies.Add(cookie);

                Response.Redirect("~/BackofficeAdmin/Default.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            string usuario = tbUsuario.Text;
            string clave = tbClave.Text;

            if (usuario == "admin" && clave == "admin")
            {
                #region cookie
                HttpCookie cookie = new HttpCookie("UsuarioSettings");
                cookie["usuario"] = usuario;
                cookie.Expires = DateTime.Now.AddMinutes(3);
                HttpContext.Current.Response.Cookies.Add(cookie);
                #endregion

                Response.Redirect("~/BackofficeAdmin/Default.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            else
            {
                lbError.Text = "Error. Usuario o contraseña incorrecta";
                lbError.Visible = true;
            }
        }
    }
}