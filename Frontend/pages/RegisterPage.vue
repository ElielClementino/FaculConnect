<template>
  <v-app>
    <v-container fluid>
      <v-row class="fill-height">
        <v-col cols="5" class="pa-4 d-flex justify-center align-center bg-dark">
        <div>
        <p class="color--white text-style top-title"><svg style="color: 6BE7E7; padding-top:4px;" xmlns="http://www.w3.org/2000/svg" width="1em" height="1em" viewBox="0 0 24 24">
		<path fill="currentColor" d="M21 18.5h-6.18A3 3 0 0 0 13 16.68V13.5h3.17a4.33 4.33 0 0 0 1.3-8.5A6 6 0 0 0 6.06 6.63A3.5 3.5 0 0 0 7 13.5h4v3.18a3 3 0 0 0-1.82 1.82H3a1 1 0 0 0 0 2h6.18a3 3 0 0 0 5.64 0H21a1 1 0 0 0 0-2m-14-7a1.5 1.5 0 0 1 0-3a1 1 0 0 0 1-1a4 4 0 0 1 7.79-1.29a1 1 0 0 0 .78.67a2.31 2.31 0 0 1 1.93 2.29a2.34 2.34 0 0 1-2.33 2.33Zm5 9a1 1 0 1 1 1-1a1 1 0 0 1-1 1" />
	    </svg><span style="font-weight: 100;">Facul</span>Connect</p>
        </div>
          <div class="text-center" style="line-height:10vh;">
        <h2 class="text-h4 text-style">Seja bem-vindo!</h2>
            <p class="text-style">Acesse a sua conta agora mesmo.</p>
            <v-btn rounded class="mt-5 pa-6 text-style" width=150 outlined>
              Entrar
            </v-btn>
          </div>
        </v-col>
        <v-col cols="7" class="pa-4 d-flex justify-center align-center bg-white">
          <div>
            <h2 class="create-account">Crie sua Conta</h2>
            <p class="create-account">Preencha os campos abaixo para criar a sua conta.</p>
            <v-form>
              <v-text-field
                background-color="#BAB8B8"
                color="#000000"
                placeholder="Preencha o nome de usuário"
                label="Nome de usuário"
                prepend-inner-icon="mdi-account"
                filled
                dark
                v-model="form.nomeUsuario"
              ></v-text-field>
              <v-text-field
                background-color="#BAB8B8"
                color="#000000"
                text-color="red"
                placeholder="Preencha com o seu Email"
                label="Email"
                prepend-inner-icon="mdi-email"
                filled
                v-model="form.email"
              ></v-text-field>
              <v-text-field
                background-color="#BAB8B8"
                color="#000000"
                placeholder="Preencha com a sua senha"
                label="Senha"
                prepend-inner-icon="mdi-lock"
                filled
                type="password"
                v-model="form.senha"
              ></v-text-field>
              <div class="text-center">
                <v-btn rounded class="pa-6 mt-5 text-style" color="#010101">
                  Cadastrar
                </v-btn>
              </div>
            </v-form>
          </div>
        </v-col>
      </v-row>
    </v-container>
  </v-app>
</template>

<script>
export default {
  data() {
    return {
      form: {
        nomeUsuario: '',
        email: '',
        senha: ''
      }
    }
  }
}
</script>

<style scoped>
body {
    margin: 0;
    width: 100%;
}

.fill-height {
    height: 100vh;
}

.bg-dark {
    background-color: #010101;
}

.bg-white {
    background-color: #FFF;
}

.create-account {
    color: #010101;
    text-align: center;
    font-weight: 900;
    font-family: Poppins, sans-serif;
}

.top-title {
  position: absolute;
  top: 50px;
  left: 50px;
}

.text-style {
    font-family: Poppins, sans-serif;
    font-weight: 900;
}

</style>
