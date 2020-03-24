const { colors } = require('tailwindcss/defaultTheme');

module.exports = {
    
    theme: {
        colors: {
            gray: colors.gray,
            orange: colors.orange
        },
        fontFamily: {
            sans: [
                'Inter',
                'sans-serif'
            ],
            title: [
                'Abril Fatface',
                'cursive'
            ],
            heading: [
                'Lato',
                'sans-serif'
            ],
            button: [
                'Fira Sans',
                'sans-serif'
            ]
        },
        extend: {
            backgroundSize: {
                
                '110%': '110%',
                '120%': '120%'
            },
            backgroundPosition: {
                'center-bottom-40': 'center bottom 40%',
                'center-bottom-10': 'center bottom 10%'
            },
            lineheight: {
                '12': '3rem'
            },
            height: {
                '14': '3.5rem',
                //'50': '13rem',
                //'72': '18rem',
                //'78': '20rem',
                '110': '27.5rem',
                //'135': '33.75rem',
                //'138': '34.5rem',
                //'140': '35rem',
                //'144': '36rem',
                //'152': '38rem'
            },
            //width: {
            //    //'60': '15rem',
            //    //'70': '17rem',
            //    //'71': '17.5rem',
            //    //'72': '18rem',
            //    //'73': '18.5rem',
            //    //'74': '19rem',
            //    //'75': '19.5rem',
            //    //'78': '20rem',
            //    //'82': '21rem',
            //    //'83': '21.5rem',
            //    //'86': '22rem',
            //    //'94': '30rem'
            //},
            borderRadius: {
                large: '12px'
            },
            margin: {
                '76': '19rem',
                '-94': '-23.5rem',
                '110': '27.5rem',
                '170': '42.5rem'
            },
            screens: {
                'hd': '1680px'
            }
        }
    },
    variants: {},
    plugins: []
}