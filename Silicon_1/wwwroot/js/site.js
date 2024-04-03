
document.addEventListener('DOMContentLoaded', function () {

    darkModeSwitch()

})


function darkModeSwitch() {

    try {

        let sw = document.querySelector('#switch-mode')
        sw.addEventListener('change', function () {
            let mode = this.checked ? 'dark' : 'light'

            fetch(`/sitesettings/theme?mode=${mode}`)
                .then(res => {
                    if (res.ok)
                        window.location.reload()
                    else
                        console.log('unable to switch theme mode')
                })
        })

    }
    catch { }
}