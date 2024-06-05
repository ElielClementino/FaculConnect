<template>
<v-app style="background-color:#ffffff;">
  <SideBar />
  <NavBar />
  <v-card
    style="box-shadow: none;"
    class="mx-auto"
    max-width="344"
  >
    <v-card-text class="bg-black card">
      <div style="text-align:center;" class="text-style color-white">
      <h1 class="course-title">ANÁLISE E DESENVOLVIMENTO DE SISTEMAS</h1>
      </div>
      <v-divider style="border-color:#FFFFFF; margin-top:8px"></v-divider>
      <div class="course-info">
      <p style="font-size:2vh;" class="text-style color-green">INSCRIÇÕES ABERTAS</p>
      <p style="font-size:2vh;" class="text-style color-light-green">R$ 120,00/Mês</p>
      </div>
      <div class=" text-style color-white">
        <p>Este curso ensina a projetar, implementar e manter softwares, abordando desde a análise de requisitos até a programação e testes. Prepara profissionais para desenvolver soluções tecnológicas e eficazs e inovadoras.</p>
      </div>
    </v-card-text>
    <div class="div-button">
      <v-btn
        style="padding:25px;"
        color=#0856CA
      >
        <p style="margin-bottom:0" class="text-style color-white">Se inscrever</p>
      </v-btn>
    </div>
  </v-card>
</v-app>
</template>

<style>

.color-white {
    color: #FFFFFF;
}

.color-green {
    color: #1BA541;
}

.color-light-green {
    color: #ABDE9A;
}

.color-red {
    color: #FF0202;   
}

.bg-black {
    background-color: #010101;
}

.course-info {
    display:flex;
    justify-content:space-between;
    margin-bottom: 14px;
}

.course-title {
    font-size:5vh;
    line-height: 6vh;
}

.card {
    border-radius: 12px;
    box-shadow: 0 0 2px rgba(0, 0, 0, 0.1);
}

.div-button {
    display:flex;
    justify-content:center;
    text-align:center;
    background-color: #ffffff;
}

.text-style {
    font-family: Poppins, sans-serif;
    font-weight: 900;

}
</style>
