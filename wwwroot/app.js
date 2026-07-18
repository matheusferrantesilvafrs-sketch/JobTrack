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

        const targetData =
            buttonParent.getAttribute('data-target');

        const dadosNovos = conteudos[targetData];

        if (!dadosNovos) {
            return;
        }

        container.innerHTML = '';

        if (dadosNovos.exibirTemplate) {
            welcomeTitle.textContent = '';
            welcomeParagraph.textContent = '';

            const clone =
                template.content.cloneNode(true);

            container.appendChild(clone);

            ativarFormularioCadastro();
            carregarCadastros();

            return;
        }

        welcomeTitle.textContent =
            dadosNovos.titulo ?? '';

        welcomeParagraph.textContent =
            dadosNovos.texto ?? '';
    });
});

function ativarFormularioCadastro() {
    const formulario =
        container.querySelector('#formCadastro');

    if (!formulario) {
        console.error(
            'O formulário de cadastro não foi encontrado.'
        );

        return;
    }

    formulario.addEventListener(
        'submit',
        realizarCadastro
    );
}

async function realizarCadastro(event) {
    event.preventDefault();

    const empresa =
        container.querySelector('#Empresa').value.trim();

    const cargo =
        container.querySelector('#Cargo').value.trim();

    const data =
        container.querySelector('#Data').value;

    const descricoes =
        container.querySelector('#Descricoes').value.trim();

    if (!empresa || !cargo || !data || !descricoes) {
        alert('Preencha todos os campos.');

        return;
    }

    const novoCadastro = {
        empresa: empresa,
        cargo: cargo,
        data: data,
        descricoes: descricoes
    };

    try {
        const resposta = await fetch('/dadoscad', {
            method: 'POST',

            headers: {
                'Content-Type': 'application/json'
            },

            body: JSON.stringify(novoCadastro)
        });

        if (!resposta.ok) {
            const erroCompleto = await resposta.text();

            console.error('Erro retornado pela API:', erroCompleto);

            alert(`Erro ${resposta.status}: verifique o console e o terminal.`);

            return;
        }

        const cadastroCriado =
            await resposta.json();

        console.log(
            'Cadastro criado:',
            cadastroCriado
        );

        alert('Cadastro realizado com sucesso!');

        event.target.reset();

        await carregarCadastros();
    } catch (erro) {
        console.error(
            'Erro ao conectar com a API:',
            erro
        );

        alert(
            'Não foi possível conectar com a API.'
        );
    }
}

async function obterMensagemErro(resposta) {
    try {
        const erro = await resposta.json();

        return erro.mensagem ??
            'Não foi possível realizar o cadastro.';
    } catch {
        return 'Não foi possível realizar o cadastro.';
    }
}

async function carregarCadastros() {
    try {
        const resposta = await fetch('/dadoscad');

        if (!resposta.ok) {
            console.error(
                'Não foi possível carregar os cadastros.'
            );

            return;
        }

        const cadastros = await resposta.json();

        console.log(
            'Cadastros salvos:',
            cadastros
        );
    } catch (erro) {
        console.error(
            'Erro ao consultar os cadastros:',
            erro
        );
    }
}