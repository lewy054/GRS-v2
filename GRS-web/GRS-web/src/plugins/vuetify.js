// Styles
import '@mdi/font/css/materialdesignicons.css'
import 'vuetify/styles'

// Vuetify
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'



const vuetify = createVuetify({
    components,
    directives,
    theme: {
        defaultTheme: 'myCustomTheme',
        themes: {
            myCustomTheme: {
                dark: false,
                variables: {}, // ✅ this property is required to avoid Vuetify crash

                colors: {
                    background: '#ccc',
                    surface: '#1F2933',
                    primary: '#00ff00',
                    'primary-darken-1': '#3700B3',
                    secondary: '#03DAC5',
                    'secondary-darken-1': '#03DAC5',
                },
            }
        }
    }
})
import {createVuetify} from 'vuetify'

export default vuetify;
