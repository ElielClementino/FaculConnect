<template>
  <v-app style="background-color:#ffffff;">
    <SideBar />
    <NavBar />
    <v-container
      class="courses-grid"
    >
      <v-card
        class="course-card"
        v-for="course in courses" :key="course.courseId"
      >
        <v-card-text class="bg-black card-content" style="border-radius:25px;">
          <div style="text-align:center;" class="text-style color-white">
            <h1 class="course-title"> {{ course.name }}</h1>
          </div>
          <v-divider style="border-color:#FFFFFF; margin-top:24px"></v-divider>
          <div class="course-info">
            <p style="font-size:2vh;" :class="course.availability ? 'color-green' : 'color-red'" class="text-style">{{ course.availability ? "INSCRIÇÕES ABERTAS" : "INSCRIÇÕES FECHADAS"}}</p>
            <p style="font-size:2vh;" class="text-style color-light-green">R$ {{ course.price }},00/Mês</p>
          </div>
          <div class="text-style color-white">
            <p>{{ course.description }}</p>
          </div>
        </v-card-text>
        <div class="div-button">
          <v-btn
            style="padding:25px;"
            color="#0856CA"
            :class="course.availability ? '': 'disabled-btn'"
            @click="updateStudentCourse(course)"
          >
            <p style="margin-bottom:0" class="text-style color-white">Se inscrever</p>
          </v-btn>
        </div>
      </v-card>
    </v-container>
  </v-app>
</template>



<script>

import course from "../api/course.js"
import student from "../api/student.js"

export default {
  data() {
    return {
      courses: {},
      studentInfo: {
        StudentId: null,
        CourseId: null,
      }
    }
  },
  async mounted() {
    await this.listCourses()
  },
  methods: {
    async listCourses() {
      try {
        this.courses = await course.listCourses()
        console.log(this.courses)
      } catch(error) {
        console.error(error)
      }
    },
    async getStudent() {
      try {
        const LoggedUserId = await this.$store.state.loggedUser.userId
        let result = await student.retrieve(LoggedUserId)
        this.studentInfo.StudentId = result.studentId;
        console.log(this.studentInfo.StudentId)
        console.log(result)
      } catch(error) {
        console.log(error)
      }
    },
    async updateStudentCourse(course) {
      try{
        if(!course.availability) {
          throw new Error("This course is not available")
        }
        await this.getStudent()
        this.studentInfo.CourseId = course.courseId
        let updatedStudentCourse = await student.update(this.studentInfo)
        this.$router.push('/DisciplinePage');
      } catch(error) {
        console.log(error)
      }
    }
  }
}
</script>

<style>
.courses-grid {
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  gap: 16px;
  margin-top: 100px;
  margin-right: 7%;
  margin-bottom: 100px;
}

.course-card {
  display: flex;
  flex-direction: column;
  text-align:center;
  justify-content: space-between;
  width: 80%;
  height: 100%;
  background-color: #ffffff !important;
  box-shadow:none !important;
}

.card-content {
  flex-grow: 1;
}

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
    display: flex;
    justify-content: space-between;
    margin-top:14px;
}

.course-title {
    font-size: 5vh;
    line-height: 6vh;
}

.div-button {
    text-align: center;
    background-color: rgb(255, 255, 255, 1);
    border: none;

}

.text-style {
    font-family: Poppins, sans-serif;
    font-weight: 900;
}

.disabled-btn {
  background-color: #0856CA !important;
  opacity: 0.5;
  cursor: not-allowed;
}
</style>
