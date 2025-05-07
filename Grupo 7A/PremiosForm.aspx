<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="PremiosForm.aspx.cs" Inherits="Grupo_7A.PremiosForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <h1 class="text-center mb-4">Elegí tu premio</h1>

    <div class="container">
        <div class="row justify-content-center">
            <!-- Carrusel 1 -->
            <div class="col-md-5">
                <div class="custom-carousel mx-auto">
                    <div id="carouselUno" class="carousel slide" data-bs-ride="carousel">
                        <div class="carousel-inner">
                            <div class="carousel-item active">
                                <img src="https://picsum.photos/id/1018/800/400" class="d-block w-100" alt="Imagen 1">
                            </div>
                            <div class="carousel-item">
                                <img src="https://picsum.photos/id/1015/800/400" class="d-block w-100" alt="Imagen 2">
                            </div>
                            <div class="carousel-item">
                                <img src="https://picsum.photos/id/1019/800/400" class="d-block w-100" alt="Imagen 3">
                            </div>
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
                        <h5>Nombre del Carrusel 1</h5>
                        <p>Descripción breve de las imágenes mostradas aquí. Podés poner cualquier texto.</p>
                        <button class="btn btn-primary">Seleccionar</button>
                    </div>
                </div>
            </div>

            <!-- Carrusel 2 -->
            <div class="col-md-5">
                <div class="custom-carousel mx-auto">
                    <div id="carouselDos" class="carousel slide" data-bs-ride="carousel">
                        <div class="carousel-inner">
                            <div class="carousel-item active">
                                <img src="https://picsum.photos/id/1020/800/400" class="d-block w-100" alt="Imagen 1">
                            </div>
                            <div class="carousel-item">
                                <img src="https://picsum.photos/id/1021/800/400" class="d-block w-100" alt="Imagen 2">
                            </div>
                            <div class="carousel-item">
                                <img src="https://picsum.photos/id/1022/800/400" class="d-block w-100" alt="Imagen 3">
                            </div>
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
                        <h5>Nombre del Carrusel 2</h5>
                        <p>Otra descripción distinta para estas imágenes. Ideal para mostrar info del producto, galería, etc.</p>
                        <button class="btn btn-primary">Seleccionar</button>
                    </div>
                </div>
            </div>

            <!-- Carrusel 3 -->
            <div class="col-md-5">
                <div class="custom-carousel mx-auto">
                    <div id="carouselTres" class="carousel slide" data-bs-ride="carousel">
                        <div class="carousel-inner">
                            <div class="carousel-item active">
                                <img src="https://picsum.photos/id/1020/800/400" class="d-block w-100" alt="Imagen 1">
                            </div>
                            <div class="carousel-item">
                                <img src="https://picsum.photos/id/1021/800/400" class="d-block w-100" alt="Imagen 2">
                            </div>
                            <div class="carousel-item">
                                <img src="https://picsum.photos/id/1022/800/400" class="d-block w-100" alt="Imagen 3">
                            </div>
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
                        <h5>Nombre del Carrusel 3</h5>
                        <p>Otra descripción distinta para estas imágenes. Ideal para mostrar info del producto, galería, etc.</p>
                        <button class="btn btn-primary">Seleccionar</button>
                    </div>

                </div>
            </div>
</asp:Content>
