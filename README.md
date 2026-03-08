# SEGURIDAD-DE-APLICACIONES-GRUPO-2-CARLOS-MONTALUISA

Proyecto académico de **Seguridad de Aplicaciones** enfocado en la
implementación de un pipeline **DevSecOps** con análisis automático de
vulnerabilidades, pruebas unitarias y controles de seguridad integrados
dentro de un proceso de **CI/CD**.

------------------------------------------------------------------------

# Descripción

Este repositorio corresponde a un laboratorio académico de la asignatura
**Seguridad de Aplicaciones**, cuyo objetivo es implementar un pipeline
**DevSecOps** que automatice controles de seguridad durante el ciclo de
vida del desarrollo de software.

El proyecto utiliza **.NET 8** y un pipeline de **CI/CD en GitHub
Actions** para integrar pruebas automatizadas, análisis de seguridad y
verificación de dependencias vulnerables.

------------------------------------------------------------------------

# Objetivo del proyecto

Implementar un pipeline automatizado que permita:

-   Integrar controles de seguridad en el ciclo de vida del desarrollo
    de software.
-   Detectar vulnerabilidades en el código fuente.
-   Identificar dependencias con vulnerabilidades conocidas.
-   Ejecutar pruebas unitarias automáticamente.
-   Generar reportes de seguridad y análisis de código.

Este enfoque sigue el modelo **DevSecOps**, integrando seguridad desde
las primeras etapas del desarrollo.

------------------------------------------------------------------------

# Arquitectura del Pipeline DevSecOps

El pipeline implementado en este repositorio sigue un flujo de
integración continua con controles de seguridad automatizados.

``` mermaid
flowchart TD

A[Developer Push] --> B[Security Scans]

B --> C[Secret Scanning]
B --> D[SAST - Static Application Security Testing]
B --> E[Dependency Vulnerability Analysis]
B --> F[Vulnerability Scanning]

F --> G[Build Application]

G --> H[Unit Testing]

H --> I[Advanced Security Analysis]

I --> J[Security Reports]

J --> K[GitHub Security Dashboard]
```

Este flujo permite que cada cambio realizado por un desarrollador sea
automáticamente evaluado mediante controles de seguridad antes de
integrarse completamente al proyecto.

------------------------------------------------------------------------

# Controles de Seguridad Implementados

El pipeline incluye múltiples capas de seguridad:

1.  **Detección de secretos en el repositorio**\
    Previene la exposición accidental de credenciales, tokens o claves
    API.

2.  **Análisis estático de código (SAST)**\
    Permite identificar vulnerabilidades directamente en el código
    fuente.

3.  **Análisis avanzado de vulnerabilidades**\
    Realiza evaluaciones más profundas sobre posibles riesgos de
    seguridad.

4.  **Escaneo de dependencias vulnerables (SCA)**\
    Detecta librerías con vulnerabilidades conocidas mediante bases de
    datos de CVE.

5.  **Escaneo de vulnerabilidades del proyecto**\
    Analiza configuraciones y paquetes utilizados en el proyecto.

6.  **Generación de SBOM (Software Bill of Materials)**\
    Permite identificar todos los componentes utilizados en la
    aplicación.

7.  **Ejecución de pruebas unitarias automatizadas**\
    Garantiza el correcto funcionamiento del código implementado.

------------------------------------------------------------------------

# Tecnologías utilizadas

Este laboratorio utiliza herramientas modernas del ecosistema
**DevSecOps**:

-   **.NET 8**
-   **GitHub Actions**
-   **CI/CD**
-   **DevSecOps**
-   **Static Application Security Testing (SAST)**
-   **Software Composition Analysis (SCA)**
-   **SBOM (Software Bill of Materials)**

------------------------------------------------------------------------

# Estructura del repositorio

    SEGURIDAD-DE-APLICACIONES-GRUPO-2-CARLOS-MONTALUISA
    │
    ├── src/
    │   Código fuente del proyecto
    │
    ├── tests/
    │   Pruebas unitarias
    │
    └── .github/
        └── workflows/
            Pipeline CI/CD y controles DevSecOps

------------------------------------------------------------------------

# Resultados esperados

Al finalizar la implementación se espera contar con:

-   Un pipeline **CI/CD seguro**.
-   Automatización de **pruebas de seguridad**.
-   Reportes automáticos de **vulnerabilidades**.
-   Integración de seguridad en el **proceso de desarrollo**.
-   Visualización de alertas de seguridad dentro del **Security
    Dashboard de GitHub**.

------------------------------------------------------------------------

# Autor

**Carlos Montaluisa**\
Proyecto académico -- Seguridad de Aplicaciones
