﻿<%@ Page Title="Búsqueda" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeFile="Aplicar.aspx.vb" Inherits="JobApplication" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="flex flex-col w-full">
        <header class="header flex flex-row items-center bg-violet-600 bg-gradient-to-r from-violet-900">
            <div class="flex items-center py-5 px-10 bg-fuchsia-500 h-full">
                <svg xmlns="http://www.w3.org/2000/svg" width="100px" height="100px" viewBox="0 0 1024 1024" fill="#000000" class="icon" version="1.1">
                    <path d="M325.36 993.322a7.94 7.94 0 0 1-5.952-2.656 7.996 7.996 0 0 1 0.61-11.294l1.702-1.61c9.24-9.09 14.318-21.228 14.318-34.18 0-26.462-21.528-47.99-47.99-47.99s-47.99 21.528-47.99 47.99a47.82 47.82 0 0 0 12.216 31.994c0.688 0.78 1.406 1.53 2.148 2.248a8 8 0 0 1 0.046 11.31 7.994 7.994 0 0 1-11.31 0.062c-0.96-0.968-1.898-1.936-2.804-2.952a63.806 63.806 0 0 1-16.292-42.664c0-35.29 28.706-63.986 63.986-63.986s63.986 28.698 63.986 63.986c0 17.262-6.772 33.446-19.074 45.568l-2.256 2.124a7.954 7.954 0 0 1-5.344 2.05z" fill="white"/>
                    <path d="M304.042 967.578a7.972 7.972 0 0 1-5.654-2.344l-31.994-31.994a7.996 7.996 0 1 1 11.31-11.31l31.994 31.994a7.996 7.996 0 0 1-5.656 13.654z" fill="white"/>
                    <path d="M280.174 991.448a7.996 7.996 0 0 1-5.656-13.654l23.872-23.87a7.996 7.996 0 1 1 11.31 11.31l-23.87 23.87a7.98 7.98 0 0 1-5.656 2.344zM272.05 935.584a7.96 7.96 0 0 1-5.476-2.172 8 8 0 0 1-0.352-11.31l61.988-65.984a8.002 8.002 0 0 1 11.654 10.964l-61.988 65.986a7.964 7.964 0 0 1-5.826 2.516z" fill="white"/>
                    <path d="M999.898 1023.442H24.102a7.994 7.994 0 0 1-7.998-8v-111.976c0-68.656 35.562-94.964 101.182-119.474 69.096-25.806 124.038-49.678 158.88-69.002 3.876-2.11 8.732-0.75 10.874 3.124a7.996 7.996 0 0 1-3.11 10.874c-35.532 19.7-91.214 43.912-161.052 70.002-61.502 22.962-90.778 44.458-90.778 104.476v103.978h959.8v-103.978c0-60.018-29.276-81.514-90.778-104.476-71.016-26.574-125.208-50.13-161.06-70.002a8.006 8.006 0 0 1-3.124-10.874c2.14-3.876 7.014-5.234 10.874-3.124 35.164 19.496 88.638 42.71 158.92 69.002 65.612 24.51 101.166 50.818 101.166 119.474v111.976a7.996 7.996 0 0 1-8 8z" fill="white"/>
                    <path d="M512 735.5c-111.078 0-287.94-157.404-287.94-343.928 0-4.422 3.576-8 7.998-8a7.994 7.994 0 0 1 7.998 8c0 177.854 167.036 327.932 271.944 327.932 104.916 0 271.944-150.078 271.944-327.932 0-4.422 3.578-8 8-8a7.994 7.994 0 0 1 7.996 8c0 186.524-176.87 343.928-287.94 343.928zM512.476 799.488c-4.414 0-8.076-3.578-8.076-8 0-4.42 3.5-7.998 7.92-7.998h0.156a7.994 7.994 0 0 1 7.998 7.998c0 4.422-3.576 8-7.998 8zM512.476 863.472c-4.414 0-8.076-3.576-8.076-7.996 0-4.422 3.5-8 7.92-8h0.156a7.994 7.994 0 0 1 7.998 8 7.992 7.992 0 0 1-7.998 7.996zM512.476 927.46c-4.414 0-8.076-3.578-8.076-7.998 0-4.422 3.5-7.998 7.92-7.998h0.156a7.992 7.992 0 0 1 7.998 7.998 7.994 7.994 0 0 1-7.998 7.998zM512.476 991.448c-4.414 0-8.076-3.576-8.076-7.998s3.5-7.998 7.92-7.998h0.156c4.422 0 7.998 3.576 7.998 7.998s-3.576 7.998-7.998 7.998z" fill="white"/>
                    <path d="M711.958 703.508a7.994 7.994 0 0 1-7.998-8v-31.992c0-4.422 3.576-7.998 7.998-7.998s7.998 3.576 7.998 7.998v31.992a7.992 7.992 0 0 1-7.998 8z" fill="white"/>
                    <path d="M631.974 815.484a7.996 7.996 0 0 1-4.654-1.484 8.002 8.002 0 0 1-1.844-11.17l79.982-111.976a8.046 8.046 0 0 1 11.156-1.86 8.002 8.002 0 0 1 1.842 11.17l-79.982 111.976a7.986 7.986 0 0 1-6.5 3.344z" fill="white"/>
                    <path d="M631.974 815.484a7.86 7.86 0 0 1-3.576-0.844l-95.98-47.99a8.002 8.002 0 0 1-3.578-10.732 8.002 8.002 0 0 1 10.732-3.578l95.98 47.99a8 8 0 1 1-3.578 15.154zM312.042 703.508a7.994 7.994 0 0 1-7.998-8v-31.992a7.994 7.994 0 0 1 7.998-7.998c4.422 0 8 3.576 8 7.998v31.992a7.998 7.998 0 0 1-8 8z" fill="white"/>
                    <path d="M392.034 815.484a7.968 7.968 0 0 1-6.514-3.344l-79.984-111.976a8.01 8.01 0 0 1 1.86-11.17 8.02 8.02 0 0 1 11.154 1.86l79.982 111.976a8.012 8.012 0 0 1-1.858 11.17c-1.408 1-3.032 1.484-4.64 1.484z" fill="white"/>
                    <path d="M392.034 815.484a8 8 0 0 1-3.586-15.154l95.98-47.99c3.954-1.984 8.74-0.36 10.732 3.578a8 8 0 0 1-3.578 10.732l-95.98 47.99a7.9 7.9 0 0 1-3.568 0.844zM232.058 367.576a8.012 8.012 0 0 1-7.966-7.248c-9.888-105.62 13.028-189.836 68.118-250.324C374.584 19.54 510.446 0.558 609.918 0.558c56.238 0 95.356 6.14 97.01 6.39a8.02 8.02 0 0 1 6.688 6.984 8.004 8.004 0 0 1-4.906 8.31c-57.208 23.542-47.928 80.482-43.146 99.042a143.8 143.8 0 0 1 5.56-0.108c22.73 0 65.596 5.53 97.34 42.616 34.852 40.694 45.412 106.994 31.382 197.022a7.988 7.988 0 0 1-6.342 6.608 7.964 7.964 0 0 1-8.388-3.67L718.364 254.6c-25.306 9.794-120.068 44.038-208.644 44.038-88.302 0-181.916-34.056-207.292-43.96l-63.456 108.932a8.026 8.026 0 0 1-6.914 3.966z m489.602-130.894c2.702 0 5.326 1.39 6.826 3.828l58.55 95.73c8.452-73.876-1.86-128.334-30.712-162.044-27.588-32.212-65.22-37.024-85.202-37.024-6.202 0-10.06 0.484-10.31 0.514-3.67 0.532-7.404-1.702-8.654-5.296-0.282-0.812-24.588-73.266 28.166-112.508-16.824-1.624-41.444-3.328-70.406-3.328-96.246 0-227.438 18.074-305.882 104.212-47.428 52.084-69.508 123.396-65.776 212.268l53.818-92.386a8.01 8.01 0 0 1 9.998-3.344c1.084 0.454 109.766 45.334 207.644 45.334 97.916 0 207.784-44.896 208.894-45.35a8.062 8.062 0 0 1 3.046-0.606z" fill="white"/>
                    <path d="M615.978 1007.444a7.992 7.992 0 0 1-7.998-7.998v-95.98a7.994 7.994 0 0 1 7.998-7.998h79.984a7.994 7.994 0 0 1 7.998 7.998c0 4.422-3.578 8-7.998 8h-71.986v87.98a7.992 7.992 0 0 1-7.998 7.998z" fill="white"/>
                    <path d="M839.932 1007.444a7.994 7.994 0 0 1-7.998-7.998v-87.98h-71.984a7.994 7.994 0 0 1-7.998-8 7.994 7.994 0 0 1 7.998-7.998h79.982c4.422 0 8 3.578 8 7.998v95.98a7.994 7.994 0 0 1-8 7.998z" fill="white"/>
                    <path d="M743.952 911.464H711.96a7.994 7.994 0 0 1-7.998-8v-31.992c0-4.422 3.576-8 7.998-8h31.992c4.422 0 8 3.578 8 8v31.992c0 4.422-3.578 8-8 8z m-23.994-15.998h15.998v-15.996h-15.998v15.996z" fill="white"/>
                    <path d="M711.958 919.462a7.994 7.994 0 0 1-7.998-7.998v-8c0-4.42 3.576-7.998 7.998-7.998s7.998 3.578 7.998 7.998v8a7.992 7.992 0 0 1-7.998 7.998z" fill="white"/>
                    <path d="M743.952 919.462a7.992 7.992 0 0 1-7.996-7.998v-8a7.992 7.992 0 0 1 7.996-7.998c4.422 0 8 3.578 8 7.998v8a7.994 7.994 0 0 1-8 7.998z" fill="white"/>
                    <path d="M791.944 959.454h-127.974a7.994 7.994 0 0 1-7.998-7.998 7.994 7.994 0 0 1 7.998-7.998h127.974a7.992 7.992 0 0 1 7.996 7.998 7.992 7.992 0 0 1-7.996 7.998z" fill="white"/>
                    <path d="M759.95 991.448h-63.986c-4.422 0-8-3.576-8-7.998s3.578-7.998 8-7.998h63.986c4.42 0 7.998 3.576 7.998 7.998s-3.578 7.998-7.998 7.998z" fill="white"/>
                </svg>
            </div>
            <div class="prose py-10">
                <h1 class="px-10 !my-2 !text-violet-100">Aplicaci&oacute;n a Vacante</h1>
                <h2 ID="LabelTituloDeTrabajo" runat="server" class="px-10 !my-2 !text-violet-100"></h2>
            </div>
        </header>

        <div id="ContenedorDeError" class="mx-auto flex flex-col w-1/2 my-10" runat="server" visible="false">
            <p class="prose prose-lg w-full">
                Ha ocurrido un error:<br />
                <asp:Literal ID="LiteralErrorText" runat="server"></asp:Literal>
            </p>
        </div>

        <div id="ContenedorDeFormualario" class="mx-auto flex flex-col w-1/2 my-10" runat="server">
            <div class="prose prose-lg my-5">
                <h3 class="!text-violet-100">Descripci&oacute;n:</h3>
                <div class="prose prose-lg w-full !text-white !my-0">
                    <asp:Literal ID="ParrafoDescripcionDeTrabajo" runat="server" Mode="PassThrough"></asp:Literal>
                </div>
            </div>

            <section class="grid grid-cols-4-form gap-5 auto-cols-max items-center my-8 !text-white">
                <div class="prose prose-lg my-5 col-span-4 !my-0">
                    <h3 class="!text-white">Datos Generales</h3>
                </div>
                <label for="nombre">Nombre:</label>
                <asp:TextBox ID="TextBoxNombre" CssClass="input input-bordered" runat="server" />
                <label for="apellido">Apellido:</label>
                <asp:TextBox ID="TextBoxApellido" CssClass="input input-bordered" runat="server" />
                <label for="nombre">Edad:</label>
                <asp:TextBox ID="TextBoxEdad" CssClass="input input-bordered" TextMode="Number" runat="server" />
                <label for="apellido">Fecha De Nacimiento:</label>
                <asp:TextBox ID="TextBoxFechaDeNacimiento" CssClass="input input-bordered" TextMode="Date" runat="server" />
            </section>

            <section class="grid grid-cols-1 gap-5 auto-cols-max items-center my-8 !text-white">
                <div class="prose prose-lg col-span-1 !my-0">
                    <h3 class="!text-white">Aptitudes y Experiencia</h3>
                </div>
                <label for="educacion" class="col-span-1">Educaci&oacute;n:</label>
                <asp:TextBox ID="TextBoxEducacion" CssClass="textarea textarea-bordered textarea-xs col-span-1 w-full h-48" TextMode="MultiLine" Rows="5" runat="server" />
                <label for="habilidades" class="col-span-1">Habilidades y Destrezas:</label>
                <asp:TextBox ID="TextBoxHabilidades" CssClass="textarea textarea-bordered textarea-xs col-span-1 w-full h-48" TextMode="MultiLine" Rows="5" runat="server" />
                <label for="experiencias" class="col-span-1">Experiencia:</label>
                <asp:TextBox ID="TextBoxExperiencia" CssClass="textarea textarea-bordered textarea-xs col-span-1 w-full h-48" TextMode="MultiLine" Rows="5" runat="server" />
                <label for="hoja-de-vida">Hoja de Vida:</label>
                <asp:FileUpload ID="FileUploadCV" runat="server" AllowMultiple="false" />
            </section>

            <section class="grid grid-cols-4-form gap-5 auto-cols-max items-center my-8 !text-white">
                <div class="prose prose-lg my-5 col-span-4 !my-0">
                    <h3 class="!text-white">Contacto</h3>
                </div>
                <label for="telefono">Tel&eacute;fono:</label>
                <asp:TextBox ID="TextBoxTelefono" CssClass="input input-bordered" TextMode="Phone" runat="server" />
                <label for="email">Email:</label>
                <asp:TextBox ID="TextBoxEmail" CssClass="input input-bordered" TextMode="Email" runat="server" />
            </section>

            <asp:Button ID="ButtonAplicar" runat="server" CssClass="btn btn-primary bg-fuchsia-400 self-center w-64 mt-7 mb-10" OnClick="ButtonAplicar_Click" Text="Aplicar" />
        </div>

        <div id="ContenedorDeConfirmacion" class="flex flex-col w-1/2 mx-auto my-10 w-full" runat="server" visible="false">
            <div class="prose prose-lg !text-white mx-auto">
                <h2 class="!text-white text-center">Confirmaci&oacute;n</h2>

                <p class="mx-auto mt-10">
                    Su aplicaci&oacute;n ha sido registrada satisfactorialmente y ser&aacute; evaluada por el publicante de la vacante.  
                    De ser seleccionado se le estar&aacute; contactando para coordinar los siguientes pasos en v&iacute;as a una contrataci&oacute;n. 
                    El publicante ha de marcar su aplicaci&oacute;n como evaluada como m&iacute;nimo.
                </p>
            </div>
            
            <asp:HyperLink NavigateUrl="/Search.aspx" CssClass="btn btn-primary bg-fuchsia-500 w-1/6 mt-10 mx-auto" runat="server">Ver Vacantes</asp:HyperLink>
        </div>
    </div>
</asp:Content>

