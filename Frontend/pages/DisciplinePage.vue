<template>
  <v-app style="background-color:#ffffff;">
    <SideBar/>
    <NavBar NavTitle="ANÁLISE E DESENVOLVIMENTO DE SISTEMAS"/>
    <v-container class="main-container">
        <div class="discipline-div">
        <h1 class="color-black text-style">DISCIPLINAS</h1>
        <h2 class="color-black text-style">1º SEMESTRE</h2>
        </div>
        <v-divider class="border-divider"></v-divider>
        <v-row v-if="!loading && disciplinesInfo.length > 0">
        <v-col cols="12" md="6">
            <v-card class="pa-5 content-card bg-white">
            <v-card-title style="font-size:1.4em;" class="text-style color-black"> {{disciplinesInfo[0].name}} </v-card-title>
            <v-card-subtitle class="mb-2 color-gray text-style text-center">Módulo com 8 aulas de 40 minutos cada</v-card-subtitle>
            <v-list class="bg-white">
                <v-list-item  v-for="(lesson, index) in lessonsDiscipline1" :key="index">
                    <v-list-item-content class="color-black text-style bg-white">
                        <div class="list-div">
                            <p class="list-number">{{ index + 1 }}</p>
                            <p>{{ lesson?.name }}</p>
                        </div>
                    </v-list-item-content>
                </v-list-item>
            </v-list>
            </v-card>
        </v-col>
        <v-divider style="margin-top:50px;;" class="border-divider" vertical></v-divider>
        <v-col cols="12" md="6">
            <v-card class="pa-5 content-card bg-white">
            <v-card-title style="font-size:1.4em;" class="text-style color-black">{{ disciplinesInfo[1].name }}</v-card-title>
            <v-card-subtitle class="mb-2 color-gray text-style text-center">Módulo com 8 aulas de 40 minutos cada</v-card-subtitle>
            <v-list class="bg-white">
                <v-list-item v-for="(lesson, index) in lessonsDiscipline2" :key="index">
                    <v-list-item-content class="color-black text-style">
                        <div class="list-div">
                        <p class="list-number">{{ index + 1 }}</p>
                        <p>{{ lesson?.name }}</p>
                        </div>
                    </v-list-item-content>
                </v-list-item>
            </v-list>
            </v-card>
        </v-col>
        </v-row>
    </v-container>
  </v-app>
</template>

<script>
import discipline from '../api/discipline.js'
import student from "../api/student.js"
import lesson from '../api/lesson.js'

export default {
  data() {
    return {
      studentInfo: {
        StudentId: null,
        CourseId: null,
      },
      loading: false,
      disciplinesInfo: [],
      lessonsDiscipline1:[],
      lessonsDiscipline2:[],
      semester: 1
    }
  },
  async mounted() {
    await this.getCourseDisciplines()
    await this.getDisciplinesLessons()
  },
  methods: {
    async getStudent() {
      try {
        const LoggedUserId = await this.$store.state.loggedUser.userId
        let result = await student.retrieve(1)
        this.studentInfo.StudentId = result.studentId;
        this.studentInfo.CourseId = result.courseId;
      } catch(error) {
        console.log(error)
      }
    },
    async getCourseDisciplines() {
        try {
            this.loading = true;
            await this.getStudent()
            this.disciplinesInfo = await discipline
            .retrieveCourseDisciplines(this.studentInfo.CourseId, this.semester)
        } catch(error) {
            console.error(error)
        } finally {
            this.loading = false;
        }
    },
    async getDisciplinesLessons() {
        try {
            this.loading = true;
            if (this.disciplinesInfo.length > 0) {
                const [lessonsDiscipline1, lessonsDiscipline2] = await Promise.all([
                    lesson.retrieveDisciplinesLessons(this.disciplinesInfo[0].disciplineId),
                    lesson.retrieveDisciplinesLessons(this.disciplinesInfo[1].disciplineId)
                ]);

                this.lessonsDiscipline1 = lessonsDiscipline1;
                this.lessonsDiscipline2 = lessonsDiscipline2;

                console.log(this.lessonsDiscipline1[0].name);
                console.log(this.lessonsDiscipline2);
            }
        } catch(error) {
            console.error(error)
        } finally {
            this.loading = false;
        }
    }
  }
}
</script>

<style scoped>
.main-container {
    display: flex;
    flex-direction: column;
    padding: 0 !important;
    margin-top:70px;
    margin-right:50px;
    max-width:90% !important;
}

.discipline-div {
    display:flex;
    justify-content:space-between;
}
.content-card {
    box-shadow:none !important;
}

.color-white {
    color: #FFFFFF !important;
}

.color-gray {
    color:#808080 !important;
}

.color-black {
    color: #010101 !important;
}

.border-divider {
    border-color: #010101 !important;
}

.bg-white {
    background-color: #ffffff !important;
}

.text-style {
    font-family: Poppins, sans-serif;
    font-weight: 900;
}

.list-div {
    display:flex;
    text-align:center;
    align-items:center;
}

.list-div > p {
    margin-right: 20px;
}

.list-number {
    width:24px;
    height:16px;
    border-radius: 50%;
    background-color: #B0B0B0;
}
</style>
