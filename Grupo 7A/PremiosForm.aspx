<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="PremiosForm.aspx.cs" Inherits="Grupo_7A.PremiosForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 style="margin-top:10px; margin-bottom:10px" class="text-center mb-4">¡Elegí tu premio!</h1>
    
    <div class="container">
        <div class="row justify-content-center">
            <!-- Carrusel 1 -->
            <div class="col-md-4">
                <div class="custom-carousel mx-auto">
                    <div id="carouselUno" class="carousel slide" data-bs-ride="carousel">
                        <div class="carousel-inner">
                            <asp:Literal ID="litCarouselUno" runat="server" />
                        </div>
                        <button class="carousel-control-prev" type="button" data-bs-target="#carouselUno" data-bs-slide="prev">
                            <span class="carousel-control-prev-icon"></span>
                            <span class="visually-hidden">Anterior</span>
                        </button>
                        <button class="carousel-control-next" type="button" data-bs-target="#carouselUno" data-bs-slide="next">
                            <span class="carousel-control-next-icon"></span>
                            <span class="visually-hidden">Siguiente</span>
                        </button>
                    </div>

                    <!-- Texto y botón debajo -->
                    <div class="text-center mt-3">
                        <h5><asp:Literal ID="litTituloUno" runat="server" /></h5>
                        <p><asp:Literal ID="litDescripcionUno" runat="server" /></p>
                        <asp:Button ID="btnSeleccionarUno" runat="server" CssClass="btn btn-primary btn-select" CommandName="Seleccionar" CommandArgument="1" OnCommand="btnSeleccionarUno_Command" Text="¡Seleccionar!"/>
                    </div>
                </div>
            </div>

            <!-- Carrusel 2 -->
            <div class="col-md-4">
                <div class="custom-carousel mx-auto">
                    <div id="carouselDos" class="carousel slide" data-bs-ride="carousel">
                        <div class="carousel-inner">
                            <asp:Literal ID="litCarouselDos" runat="server" />                        
                        </div>
                        <button class="carousel-control-prev" type="button" data-bs-target="#carouselDos" data-bs-slide="prev">
                            <span class="carousel-control-prev-icon"></span>
                            <span class="visually-hidden">Anterior</span>
                        </button>
                        <button class="carousel-control-next" type="button" data-bs-target="#carouselDos" data-bs-slide="next">
                            <span class="carousel-control-next-icon"></span>
                            <span class="visually-hidden">Siguiente</span>
                        </button>
                    </div>

                    <!-- Texto y botón debajo -->
                    <div class="text-center mt-3">
                        <h5><asp:Literal ID="litTituloDos" runat="server" /></h5>
                        <p><asp:Literal ID="litDescripcionDos" runat="server" /></p>
                        <asp:Button ID="btnSeleccionarDos" runat="server" CssClass="btn btn-primary btn-select" CommandName="Seleccionar" CommandArgument="2" OnCommand="btnSeleccionarUno_Command" Text="¡Seleccionar!" />
                    </div>
                </div>
            </div>
              
            <!-- Carrusel 3 -->
            <div class="col-md-4">
                <div class="custom-carousel mx-auto">
                    <div id="carouselTres" class="carousel slide" data-bs-ride="carousel">
                        <div class="carousel-inner">
                            <asp:Literal ID="litCarouselTres" runat="server" />                            
                        </div>
                        <button class="carousel-control-prev" type="button" data-bs-target="#carouselTres" data-bs-slide="prev">
                            <span class="carousel-control-prev-icon"></span>
                            <span class="visually-hidden">Anterior</span>
                        </button>
                        <button class="carousel-control-next" type="button" data-bs-target="#carouselTres" data-bs-slide="next">
                            <span class="carousel-control-next-icon"></span>
                            <span class="visually-hidden">Siguiente</span>
                        </button>
                    </div>

                    <!-- Texto y botón debajo -->
                    <div class="text-center mt-3">
                        <h5><asp:Literal ID="litTituloTres" runat="server" /></h5>
                        <p><asp:Literal ID="litDescripcionTres" runat="server" /></p>
                        <asp:Button ID="btnSeleccionarTres" runat="server" CssClass="btn btn-primary btn-select" CommandName="Seleccionar" CommandArgument="3" OnCommand="btnSeleccionarUno_Command" Text="¡Seleccionar!" />
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

