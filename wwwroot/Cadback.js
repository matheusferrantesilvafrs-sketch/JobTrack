let idCandidaturaEmEdicao = null;

function iniciarCadastro() {
    const formulario =
        document.querySelector("#formCadastro");

    const listaCadastros =
        document.querySelector("#listaCadastros");

    const modeloCadastro =
        document.querySelector("#modeloCadastro");

    if (
        !formulario ||
        !listaCadastros ||
        !modeloCadastro
    ) {
        console.error(
            "A tela de cadastro ainda não foi carregada."
        );

        return;
    }

    formulario.addEventListener(
        "submit",
        salvarCandidatura
    );

    carregarCadastros();
}

async function salvarCandidatura(evento) {
    evento.preventDefault();

    const formulario =
        evento.currentTarget;

    const candidatura = obterDadosFormulario();

    if (!validarCandidatura(candidatura)) {
        alert("Preencha todos os campos.");
        return;
    }

    const estaEditando =
        idCandidaturaEmEdicao !== null;

    const metodo =
        estaEditando
            ? "PUT"
            : "POST";

    const endereco =
        estaEditando
            ? `/dadoscad/${idCandidaturaEmEdicao}`
            : "/dadoscad";

    try {
        const resposta = await fetch(endereco, {
            method: metodo,

            headers: {
                "Content-Type": "application/json"
            },

            body: JSON.stringify(candidatura)
        });

        const respostaTexto =
            await resposta.text();

        if (!resposta.ok) {
            console.error(
                "Erro retornado pela API:",
                respostaTexto
            );

            alert(
                `Erro ${resposta.status}: não foi possível salvar a candidatura.`
            );

            return;
        }

        formulario.reset();

        finalizarModoEdicao();

        await carregarCadastros();
    } catch (erro) {
        console.error(
            "Erro ao salvar candidatura:",
            erro
        );

        alert(
            `Erro ao salvar: ${erro.message}`
        );
    }
}

function obterDadosFormulario() {
    return {
        empresa:
            document
                .querySelector("#Empresa")
                .value
                .trim(),

        cargo:
            document
                .querySelector("#Cargo")
                .value
                .trim(),

        data:
            document
                .querySelector("#Data")
                .value,

        descricoes:
            document
                .querySelector("#Descricoes")
                .value
                .trim(),

        plataforma:
            document
                .querySelector("#Plataforma")
                .value
                .trim(),

        link:
            document
                .querySelector("#Link")
                .value
                .trim(),

        status:
            document
                .querySelector("#Status")
                .value
                .trim()
    };
}

function validarCandidatura(candidatura) {
    return Boolean(
        candidatura.empresa &&
        candidatura.cargo &&
        candidatura.data &&
        candidatura.descricoes &&
        candidatura.plataforma &&
        candidatura.link &&
        candidatura.status
    );
}

async function carregarCadastros() {
    const listaCadastros =
        document.querySelector("#listaCadastros");

    if (!listaCadastros) {
        return;
    }

    try {
        const resposta =
            await fetch("/dadoscad");

        if (!resposta.ok) {
            const erro =
                await resposta.text();

            console.error(
                "Não foi possível carregar os cadastros:",
                erro
            );

            return;
        }

        const cadastros =
            await resposta.json();

        listaCadastros.innerHTML = "";

        cadastros.forEach(candidatura => {
            criarCardCadastro(candidatura);
        });
    } catch (erro) {
        console.error(
            "Erro ao consultar os cadastros:",
            erro
        );
    }
}

function criarCardCadastro(candidatura) {
    const modeloCadastro =
        document.querySelector("#modeloCadastro");

    const listaCadastros =
        document.querySelector("#listaCadastros");

    if (
        !modeloCadastro ||
        !listaCadastros
    ) {
        return;
    }

    const copia =
        modeloCadastro.content.cloneNode(true);

    const empresa =
        copia.querySelector(".empresa-cad");

    const cargo =
        copia.querySelector(".cargo-cad");

    const plataforma =
        copia.querySelector(
            ".plataforma-cad span"
        );

    const data =
        copia.querySelector(
            ".data-cad span"
        );

    const descricao =
        copia.querySelector(".descricao-cad");

    const status =
        copia.querySelector(".status-cad");

    const link =
        copia.querySelector(".link-cad");

    const botaoEditar =
        copia.querySelector(".btn-editar");

    const botaoExcluir =
        copia.querySelector(".btn-excluir");

    empresa.textContent =
        candidatura.empresa ?? "";

    cargo.textContent =
        candidatura.cargo ?? "";

    plataforma.textContent =
        candidatura.plataforma ?? "";

    data.textContent =
        formatarData(candidatura.data);

    descricao.textContent =
        candidatura.descricoes ??
        candidatura.descricao ??
        "";

    status.textContent =
        candidatura.status ?? "";

    aplicarClasseStatus(
        status,
        candidatura.status
    );

    link.href =
        candidatura.link || "#";

    const candidaturaId =
        candidatura.id ??
        candidatura.ID ??
        candidatura.Id ??
        candidatura.iD;

    if (botaoEditar) {
        botaoEditar.addEventListener(
            "click",
            function () {
                iniciarEdicao(candidatura);
            }
        );
    }

    if (botaoExcluir) {
        botaoExcluir.addEventListener(
            "click",
            function () {
                excluirCandidatura(
                    candidaturaId
                );
            }
        );
    }

    listaCadastros.appendChild(copia);
}

function iniciarEdicao(candidatura) {
    idCandidaturaEmEdicao =
        candidatura.id ??
        candidatura.ID ??
        candidatura.Id ??
        candidatura.iD;

    if (
        idCandidaturaEmEdicao === undefined ||
        idCandidaturaEmEdicao === null
    ) {
        alert(
            "Não foi possível identificar esta candidatura."
        );

        return;
    }

    document.querySelector("#Empresa").value =
        candidatura.empresa ?? "";

    document.querySelector("#Cargo").value =
        candidatura.cargo ?? "";

    document.querySelector("#Data").value =
        candidatura.data
            ? candidatura.data.split("T")[0]
            : "";

    document.querySelector("#Descricoes").value =
        candidatura.descricoes ??
        candidatura.descricao ??
        "";

    document.querySelector("#Plataforma").value =
        candidatura.plataforma ?? "";

    document.querySelector("#Link").value =
        candidatura.link ?? "";

    document.querySelector("#Status").value =
        candidatura.status ?? "";

    const botaoSubmit =
        document.querySelector(
            '#formCadastro button[type="submit"]'
        );

    if (botaoSubmit) {
        botaoSubmit.textContent =
            "Salvar alterações";
    }

    document
        .querySelector("#Empresa")
        ?.focus();
}

function finalizarModoEdicao() {
    idCandidaturaEmEdicao = null;

    const botaoSubmit =
        document.querySelector(
            '#formCadastro button[type="submit"]'
        );

    if (botaoSubmit) {
        botaoSubmit.textContent =
            "Cadastrar";
    }
}

async function excluirCandidatura(id) {
    if (
        id === undefined ||
        id === null
    ) {
        alert(
            "O ID da candidatura não foi encontrado."
        );

        return;
    }

    const confirmou =
        confirm(
            "Tem certeza de que deseja excluir esta candidatura?"
        );

    if (!confirmou) {
        return;
    }

    try {
        const resposta =
            await fetch(
                `/dadoscad/${id}`,
                {
                    method: "DELETE"
                }
            );

        const respostaTexto =
            await resposta.text();

        if (!resposta.ok) {
            console.error(
                "Erro retornado pela API:",
                respostaTexto
            );

            alert(
                `Erro ${resposta.status}: não foi possível excluir a candidatura.`
            );

            return;
        }

        if (
            idCandidaturaEmEdicao === id
        ) {
            const formulario =
                document.querySelector(
                    "#formCadastro"
                );

            formulario?.reset();

            finalizarModoEdicao();
        }

        await carregarCadastros();
    } catch (erro) {
        console.error(
            "Erro ao excluir candidatura:",
            erro
        );

        alert(
            `Erro ao excluir: ${erro.message}`
        );
    }
}

function aplicarClasseStatus(
    elemento,
    status
) {
    const statusNormalizado =
        status
            ?.trim()
            .toLowerCase();

    elemento.classList.remove(
        "status-analise",
        "status-entrevista",
        "status-teste",
        "status-rejeitado"
    );

    if (
        statusNormalizado === "em análise" ||
        statusNormalizado === "em analise"
    ) {
        elemento.classList.add(
            "status-analise"
        );

        return;
    }

    if (
        statusNormalizado === "entrevista"
    ) {
        elemento.classList.add(
            "status-entrevista"
        );

        return;
    }

    if (
        statusNormalizado === "teste técnico" ||
        statusNormalizado === "teste tecnico"
    ) {
        elemento.classList.add(
            "status-teste"
        );

        return;
    }

    if (
        statusNormalizado === "rejeitado" ||
        statusNormalizado === "rejeitada"
    ) {
        elemento.classList.add(
            "status-rejeitado"
        );
    }
}

function formatarData(data) {
    if (!data) {
        return "Data não informada";
    }

    const dataSemHorario =
        data.split("T")[0];

    const partes =
        dataSemHorario.split("-");

    if (partes.length !== 3) {
        return data;
    }

    const [ano, mes, dia] =
        partes;

    return `${dia}/${mes}/${ano}`;
}