const mainhead = document.querySelector('.main-head');
const showcase = document.querySelector('.showcase');
const toggler = document.querySelector('.toggler');

const links = document.querySelectorAll('.nav-btn .nav-link');

const welcomeTitle = document.querySelector('.content-text h3');
const welcomeParagraph = document.querySelector('.content-text p');

const template = document.querySelector('#Cadastro');
const container = document.querySelector('#Box');

toggler.addEventListener('click', function () {
    mainhead.classList.toggle('active');
    showcase.classList.toggle('active');
});

const conteudos = {
    event1: {
        titulo: 'Dashboard',
        texto: 'Uma aplicação web pensada para auxiliar a organizar sua vida profissional.'
    },

    event2: {
        exibirTemplate: true
    },

    event3: {
        titulo: 'Entrevistas Agendadas',
        texto: 'Acompanhe o status e prepare-se para as suas próximas entrevistas.'
    },

    event4: {
        titulo: 'Calendário Integrado',
        texto: 'Visualize seus compromissos, testes técnicos e reuniões importantes.'
    },

    event5: {
        titulo: 'Meus Feedbacks',
        texto: 'Analise os retornos das empresas para melhorar o seu perfil.'
    },

    event6: {
        titulo: 'Sugestões do Sistema',
        texto: 'Dicas inteligentes baseadas no mercado para alavancar sua carreira.'
    }
};

links.forEach(link => {
    link.addEventListener('click', function (event) {
        event.preventDefault();

        const buttonParent = link.closest('.nav-btn');

        if (!buttonParent) {
            return;
        }

        const targetData = buttonParent.getAttribute('data-target');
        const dadosNovos = conteudos[targetData];

        if (!dadosNovos) {
            return;
        }

        container.innerHTML = '';

        if (dadosNovos.exibirTemplate) {
            welcomeTitle.textContent = '';
            welcomeParagraph.textContent = '';

            const clone = template.content.cloneNode(true);

            container.appendChild(clone);

            iniciarCadastro();

            return;
        }

        welcomeTitle.textContent = dadosNovos.titulo ?? '';
        welcomeParagraph.textContent = dadosNovos.texto ?? '';
    });
});