<template>
<v-app style="background-color:#ffffff;">
    <v-container>
        <SideBar />
        <NavBar />
        <div class="mt-12 pt-6 pl-6">
        <h1 class="text-style label-color" style="font-size:3vh;">Termine de preencher suas informações para ter acesso a todos os recursos da plataforma.</h1>
        <v-form>
            <v-container>
                <v-row no-gutters class="d-flex" style="justify-content:space-between;">
                    <v-col cols="5">
                         <label class="label-color text-style">PRIMEIRO NOME</label>
                        <v-text-field
                            background-color="#BAB8B8"
                            color="#000000"
                            placeholder="PRIMEIRO NOME" 
                            filled
                            height=45px
                             />
                    </v-col>
                    <v-col cols="5">
                         <label class="label-color text-style">SOBRENOME</label>
                        <v-text-field
                            background-color="#BAB8B8"
                            color="#000000"
                            label="SOBRENOME"
                            filled
                            height=45px
                             />
                    </v-col>
                    <v-col cols="12">
                         <label class="label-color text-style">NÚMERO DE TELEFONE</label>
                        <v-text-field
                            background-color="#BAB8B8"
                            color="#000000"
                            placeholder="NÚMERO DE TELEFONE"
                            filled
                            height=45px
                            
                             />
                    </v-col>
                    <v-col cols="12">
                         <label class="label-color text-style">CPF</label>
                        <v-text-field
                            background-color="#BAB8B8"
                            color="#000000"
                            placeholder="CPF"
                            filled
                            height=45px
                             />
                    </v-col>
                    <v-col cols="12">
                        <label class="label-color text-style">ENDEREÇO</label>
                        <v-text-field
                            background-color="#BAB8B8"
                            color="#000000"
                            placeholder="ENDEREÇO"
                            filled
                            height=45px
                             />
                    </v-col>
                    <v-col cols="12">
                        <label class="label-color text-style">DATA DE NASCIMENTO</label>
                        <v-text-field
                            background-color="#BAB8B8"
                            color="#000000"
                            placeholder="DATA DE NASCIMENTO"
                            filled
                            height=45px
                             />
                    </v-col>
                </v-row>
                <v-row no-gutters>
                    <v-col cols="2" style="margin-right:25px;">
                        <v-btn rounded width=150 class="pa-6 text-style" color="#010101">
                            CANCELAR
                        </v-btn>
                    </v-col>
                    <v-col cols="2">
                        <v-btn rounded width=150 class="pa-6 text-style" color="#010101">
                            SALVAR
                        </v-btn>
                    </v-col>
                </v-row>
            </v-container>
        </v-form>
    </div>
    </v-container>
</v-app>
</template>

<script>


</script>

<style scoped>

.top-title {
  position: absolute;

}

.label-color {
    color: #010101;
}

.text-style {
    font-family: Poppins, sans-serif;
    font-weight: 900;

}

</style>
