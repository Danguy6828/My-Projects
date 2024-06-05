import { createSlice } from "@reduxjs/toolkit";
import { toast } from "react-toastify";

const themes = {
    luxury: 'luxury',
    night: 'night',
    forest: 'forest',
    coffee: 'coffee',
}

const getLocalUser = () => {
    return JSON.parse(localStorage.getItem('user')) || null
}

const getTheme = () => {
    const theme = localStorage.getItem('theme' || null)
    document.documentElement.setAttribute('data-theme', theme)
    return theme
}

const initialState = {
    user: getLocalUser(),
    theme: getTheme(),
}

const userSlice = createSlice({
    name:'user', initialState, reducers: {
        loginUser: (state, action) => {
            const user = {...action.payload.user, token:action.payload.jwt}
            state.user = user
            localStorage.setItem('user', JSON.stringify(user))
        },
        logoutUser: (state) => {
            state.user = null;
            localStorage.removeItem('user')
            toast.success('Logged Out...')
        },
        luxuryTheme: (state) => {
            const {luxury} = themes
            state.theme = luxury
            document.documentElement.setAttribute('data-theme', state.theme)
            localStorage.setItem('theme', state.theme)
        },
        nightTheme: (state) => {
            const {night} = themes
            state.theme = night 
            document.documentElement.setAttribute('data-theme', state.theme)
            localStorage.setItem('theme', state.theme)
        },
        forestTheme: (state) => {
            state.theme = themes.forest
            document.documentElement.setAttribute('data-theme', state.theme)
            localStorage.setItem('theme', state.theme)
        },
        coffeeTheme: (state) => {
            state.theme = themes.coffee
            document.documentElement.setAttribute('data-theme', state.theme)
            localStorage.setItem('theme', state.theme)
        },
    }
})

export const {loginUser, logoutUser, luxuryTheme, nightTheme, forestTheme, coffeeTheme } = userSlice.actions

export default userSlice.reducer