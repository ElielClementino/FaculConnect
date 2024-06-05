export const state = () => ({
  loggedUser: {}
})

export const actions = {
  setLoggedUser({ commit }, userResponse) {
    commit('setLoggedUser', userResponse);
  }
}

export const mutations = {
  setLoggedUser(state, loggedUser){
    state.loggedUser = loggedUser
  }
}

export const getters = {
    myGetter(state){ return state.loggedUser}
}
