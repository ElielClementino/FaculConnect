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
                            type="text"
                            background-color="#BAB8B8"
                            color="#000000"
                            placeholder="PRIMEIRO NOME" 
                            filled
                            clearable
                            height=45px
                            v-model="studentProfile.FirstName"
                        />
                    </v-col>
                    <v-col cols="5">
                         <label class="label-color text-style">SOBRENOME</label>
                        <v-text-field
                            background-color="#BAB8B8"
                            color="#000000"
                            label="SOBRENOME"
                            filled
                            clearable
                            height=45px
                            v-model="studentProfile.Surname"
                        />
                    </v-col>
                    <v-col cols="12">
                         <label class="label-color text-style">NÚMERO DE TELEFONE</label>
                        <v-text-field
                            background-color="#BAB8B8"
                            color="#000000"
                            placeholder="NÚMERO DE TELEFONE"
                            filled
                            clearable
                            height=45px
                            v-model="studentProfile.PhoneNumber"
                            
                        />
                    </v-col>
                    <v-col cols="12">
                         <label class="label-color text-style">CPF</label>
                        <v-text-field
                            background-color="#BAB8B8"
                            color="#000000"
                            placeholder="CPF"
                            filled
                            clearable
                            height=45px
                            v-model="studentProfile.Cpf"
                        />
                    </v-col>
                    <v-col cols="12">
                        <label class="label-color text-style">ENDEREÇO</label>
                        <v-text-field
                            background-color="#BAB8B8"
                            color="#000000"
                            placeholder="ENDEREÇO"
                            filled
                            clearable
                            height=45px
                            v-model="studentProfile.Address"
                        />
                    </v-col>
                    <v-col cols="12">
                        <label class="label-color text-style">DATA DE NASCIMENTO</label>
                        <v-text-field
                            type="date"
                            background-color="#BAB8B8"
                            color="#000000"
                            placeholder="DATA DE NASCIMENTO"
                            filled
                            clearable
                            height=45px
                            v-model="studentProfile.BirthDate"
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
                        <v-btn
                            rounded width=150
                            class="pa-6 text-style"
                            color="#010101"
                            @click="registerStudent"
                        >
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

import student from "../api/student.js"


export default {
  data() {
    return {
      studentProfile: {
        FirstName: null,
        Surname: null,
        PhoneNumber: null,
        Cpf: null,
        Address: null,
        BirthDate: null,
        UserId: null,
      }
    }
  },
  methods: {
    resetStudentForm() {
        let studentProfile = {
        FirstName: null,
        Surname: null,
        PhoneNumber: null,
        Cpf: null,
        Address: null,
        BirthDate: null,
        UserId: null,
      };

      this.studentProfile = studentProfile;
    },
    redirectToCourses() {
        this.$router.push('/CoursesPage');
    },
    async registerStudent() {
        try {
            if(
                this.studentProfile.FirstName === null ||
                this.studentProfile.Surname === null ||
                this.studentProfile.PhoneNumber === null ||
                this.studentProfile.Cpf === null ||
                this.studentProfile.Address === null ||
                this.studentProfile.BirthDate === null
            ) {
                throw new Error("Falta preencher algum dos campos.");
            }
            const LoggedUserId = this.$store.state.loggedUser.userId
            this.studentProfile.UserId = LoggedUserId
            let result = await student.register(this.studentProfile);
            console.log(result);
            this.resetStudentForm()
            this.redirectToCourses()
        } catch(error) {
            console.error(error);
        }
    }
  }
}

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
