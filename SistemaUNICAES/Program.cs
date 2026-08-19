class UNICAES
{
    // CONSTANTES
    const int MAX_ESTUDIANTES_UNI = 50;
    const int MAX_ESTUDIANTES_SEDE = 25;
    const int MAX_ESTUDIANTES_KINDER = 30;
    const int MAX_ESTUDIANTES_KINDER_NIVEL = 10;
    const int MAX_EMPLEADOS = 50;
    const int MAX_DOCENTES = 20;
    const int MAX_DOCENTES_UNI = 15;
    const int MAX_DOCENTES_KINDER = 5;
    const int MAX_DECANOS = 4;
    const int MAX_ADMINISTRATIVOS = 10;
    const int MAX_ORDENANZAS = 10;
    const int MAX_VIGILANTES = 6;
    const int MAX_MATERIAS_ESTUDIANTE = 3;
    const int MAX_MATERIAS_DOCENTE = 5;
    const int PERIODOS = 3;
    const int MAX_ACTIVIDADES = 5;
    const int MIN_ACTIVIDADES = 2;

    // CATALOGOS
    static string[] sedes = { "", "Santa Ana", "Ilobasco" };
    static string[] facultades = { "", "Ciencias Humanisticas", "Ciencias Empresariales", "Ingenieria y Arquitectura", "Ciencias de la Salud", "Maestrias" };
    static string[,] carreras = {
        { "", "", "", "" },
        { "", "Licenciatura en comunicaciones y periodismo", "Licenciatura en diseno grafico", "Licenciatura en idioma ingles" },
        { "", "Licenciatura en contaduria publica", "Licenciatura en administracion de empresas", "Licenciatura en ciencias juridicas" },
        { "", "Ingenieria civil", "Ingenieria en desarrollo de software", "Arquitectura" },
        { "", "Doctorado en medicina", "Licenciatura en enfermeria", "Licenciatura en quimica y farmacia" },
        { "", "Maestria en educacion", "Maestria en administracion de empresas", "Maestria en ingenieria" }
    };
    static string[] materias = {
        "",
        "Comunicacion oral y escrita",
        "Ingles tecnico",
        "Informatica basica",
        "Matematica I",
        "Programacion estructurada",
        "Base de datos",
        "Redes de computadoras",
        "Contabilidad financiera",
        "Administracion I",
        "Derecho constitucional",
        "Diseno digital",
        "Periodismo I",
        "Anatomia",
        "Enfermeria basica",
        "Quimica general",
        "Dibujo arquitectonico",
        "Educacion y curriculo",
        "Investigacion aplicada"
    };
    static string[] nivelesKinder = { "", "Kinder 4", "Kinder 5", "Kinder 6" };
    static string[] cargos = { "", "Docente universitario", "Docente de kinder", "Decano", "Administrativo", "Ordenanza", "Vigilante" };
    static string[] estadosLaborales = { "", "Activo", "Incapacidad", "Vacaciones" };

    // RELACIONES
    static int[] relacionSede = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2 };
    static int[] relacionFacultad = { 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 5, 5, 1, 2, 2, 3, 4, 5 };
    static int[] relacionCarrera = { 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 3, 1, 2, 2, 2, 2 };

    static int[] relacionMateriaFacultad = {
        1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
        2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
        3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
        4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
        5, 5, 5, 5, 5, 5, 5, 5, 5
    };
    static int[] relacionMateriaCarrera = {
        1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3,
        1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3,
        1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3,
        1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3,
        1, 1, 1, 2, 2, 2, 3, 3, 3
    };
    static int[] relacionMateria = {
        1, 2, 3, 12, 1, 2, 3, 11, 1, 2, 3, 18,
        1, 2, 3, 8, 1, 2, 3, 9, 1, 2, 3, 10,
        1, 2, 3, 4, 16, 1, 2, 3, 4, 5, 6, 7, 1, 2, 3, 16,
        1, 2, 3, 13, 1, 2, 3, 14, 1, 2, 3, 15,
        1, 18, 17, 1, 18, 9, 1, 18, 6
    };

    // ESTUDIANTES UNIVERSITARIOS
    static string[] nombresUni = new string[MAX_ESTUDIANTES_UNI];
    static string[] carnetsUni = new string[MAX_ESTUDIANTES_UNI];
    static int[] edadesUni = new int[MAX_ESTUDIANTES_UNI];
    static int[] sedesUni = new int[MAX_ESTUDIANTES_UNI];
    static int[] facultadesUni = new int[MAX_ESTUDIANTES_UNI];
    static int[] carrerasUni = new int[MAX_ESTUDIANTES_UNI];
    static int[,] materiasUni = new int[MAX_ESTUDIANTES_UNI, MAX_MATERIAS_ESTUDIANTE];
    static int[] cantidadMateriasUni = new int[MAX_ESTUDIANTES_UNI];
    static double[,,,] actividadesUni = new double[MAX_ESTUDIANTES_UNI, MAX_MATERIAS_ESTUDIANTE, PERIODOS, MAX_ACTIVIDADES];
    static int[,,] cantidadActividadesUni = new int[MAX_ESTUDIANTES_UNI, MAX_MATERIAS_ESTUDIANTE, PERIODOS];
    static double[,,] parcialesUni = new double[MAX_ESTUDIANTES_UNI, MAX_MATERIAS_ESTUDIANTE, PERIODOS];
    static double[,,] promediosPeriodosUni = new double[MAX_ESTUDIANTES_UNI, MAX_MATERIAS_ESTUDIANTE, PERIODOS];
    static bool[,,] notasRegistradasUni = new bool[MAX_ESTUDIANTES_UNI, MAX_MATERIAS_ESTUDIANTE, PERIODOS];
    static int[,] clasesTotalesUni = new int[MAX_ESTUDIANTES_UNI, PERIODOS];
    static int[,] clasesAsistidasUni = new int[MAX_ESTUDIANTES_UNI, PERIODOS];
    static int totalEstudiantesUni = 0;

    // ESTUDIANTES KINDER
    static string[] nombresKinder = new string[MAX_ESTUDIANTES_KINDER];
    static string[] niesKinder = new string[MAX_ESTUDIANTES_KINDER];
    static int[] edadesKinder = new int[MAX_ESTUDIANTES_KINDER];
    static string[] enfermedadKinder = new string[MAX_ESTUDIANTES_KINDER];
    static string[] discapacidadKinder = new string[MAX_ESTUDIANTES_KINDER];
    static int[] nivelesKinderEst = new int[MAX_ESTUDIANTES_KINDER];
    static double[,] notasKinder = new double[MAX_ESTUDIANTES_KINDER, PERIODOS];
    static bool[,] notasRegistradasKinder = new bool[MAX_ESTUDIANTES_KINDER, PERIODOS];
    static int[] clasesTotalesKinder = new int[MAX_ESTUDIANTES_KINDER];
    static int[] clasesAsistidasKinder = new int[MAX_ESTUDIANTES_KINDER];
    static int totalEstudiantesKinder = 0;

    // EMPLEADOS
    static string[] nombresEmpleado = new string[MAX_EMPLEADOS];
    static string[] apellidosEmpleado = new string[MAX_EMPLEADOS];
    static string[] duiEmpleado = new string[MAX_EMPLEADOS];
    static int[] edadEmpleado = new int[MAX_EMPLEADOS];
    static int[] sedeEmpleado = new int[MAX_EMPLEADOS];
    static int[] cargoEmpleado = new int[MAX_EMPLEADOS];
    static string[] contactoEmpleado = new string[MAX_EMPLEADOS];
    static int[] estadoEmpleado = new int[MAX_EMPLEADOS];
    static int[] facultadEmpleado = new int[MAX_EMPLEADOS];
    static int[] carreraEmpleado = new int[MAX_EMPLEADOS];
    static int[,] materiasDocenteUni = new int[MAX_EMPLEADOS, MAX_MATERIAS_DOCENTE];
    static int[] cantidadMateriasDocenteUni = new int[MAX_EMPLEADOS];
    static int[] nivelDocenteKinder = new int[MAX_EMPLEADOS];
    static bool[] facultadTieneDecano = new bool[6];
    static int[] decanoEmpleado = new int[6];
    static int totalEmpleados = 0;
    static int totalDocentes = 0;
    static int totalDocentesUni = 0;
    static int totalDocentesKinder = 0;
    static int totalDecanos = 0;
    static int totalAdministrativos = 0;
    static int totalOrdenanzas = 0;
    static int totalVigilantes = 0;

    // MENU PRINCIPAL
    static void Main(string[] args)
    {
        Inicializar();
        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine(". . . SISTEMA DE CENTRALIZACION UNICAES . . .");
            Console.WriteLine("1. Gestion de alumnos universitarios");
            Console.WriteLine("2. Gestion de alumnos de kinder");
            Console.WriteLine("3. Gestion de empleados");
            Console.WriteLine("4. Gestion de facultades y carreras");
            Console.WriteLine("5. Gestion de materias e inscripciones");
            Console.WriteLine("6. Gestion de notas y asistencia");
            Console.WriteLine("7. Reportes / consultas");
            Console.WriteLine("8. Salir");
            Console.Write("Seleccione una opcion: ");
            opcion = LeerEntero("");

            switch (opcion)
            {
                case 1:
                    MenuAlumnosUniversitarios();
                    break;
                case 2:
                    MenuAlumnosKinder();
                    break;
                case 3:
                    MenuEmpleados();
                    break;
                case 4:
                    MenuFacultadesCarreras();
                    break;
                case 5:
                    MenuMateriasInscripciones();
                    break;
                case 6:
                    MenuNotasAsistencia();
                    break;
                case 7:
                    MenuReportes();
                    break;
                default:
                    if (opcion == 8)
                    {
                        Console.WriteLine("Cerrando Programa, tenga un buen dia.");
                        Pausar();
                    }
                    else
                    {
                        Console.WriteLine("Opcion invalida.");
                        Pausar();
                    }
                    break;
            }
        } while (opcion != 8);
    }

    // INICIO
    static void Inicializar()
    {
        for (int i = 0; i < decanoEmpleado.Length; i++)
            decanoEmpleado[i] = -1;
    }

    // MENUS
    static void MenuAlumnosUniversitarios()
    {
        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine(". . . ALUMNOS UNIVERSITARIOS . . .");
            Console.WriteLine("1. Registrar alumno universitario");
            Console.WriteLine("2. Editar alumno universitario");
            Console.WriteLine("3. Eliminar alumno universitario");
            Console.WriteLine("4. Mostrar alumnos universitarios");
            Console.WriteLine("5. Buscar alumno por carnet");
            Console.WriteLine("6. Regresar");
            Console.Write("Seleccione una opcion: ");
            opcion = LeerEntero("");

            switch (opcion)
            {
                case 1:
                    RegistrarAlumnoUniversitario();
                    break;
                case 2:
                    EditarAlumnoUniversitario();
                    break;
                case 3:
                    EliminarAlumnoUniversitario();
                    break;
                case 4:
                    MostrarAlumnosUniversitarios();
                    break;
                case 5:
                    BuscarAlumnoUniversitario();
                    break;
                default:
                    if (opcion != 6)
                    {
                        Console.WriteLine("Opcion invalida.");
                        Pausar();
                    }
                    break;
            }
        } while (opcion != 6);
    }

    static void MenuAlumnosKinder()
    {
        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine(". . . ALUMNOS DE KINDER . . .");
            Console.WriteLine("1. Registrar alumno de kinder");
            Console.WriteLine("2. Editar alumno de kinder");
            Console.WriteLine("3. Eliminar alumno de kinder");
            Console.WriteLine("4. Mostrar alumnos de kinder");
            Console.WriteLine("5. Buscar alumno por NIE");
            Console.WriteLine("6. Registrar notas");
            Console.WriteLine("7. Registrar asistencia");
            Console.WriteLine("8. Regresar");
            Console.Write("Seleccione una opcion: ");
            opcion = LeerEntero("");

            switch (opcion)
            {
                case 1:
                    RegistrarAlumnoKinder();
                    break;
                case 2:
                    EditarAlumnoKinder();
                    break;
                case 3:
                    EliminarAlumnoKinder();
                    break;
                case 4:
                    MostrarAlumnosKinder();
                    break;
                case 5:
                    BuscarAlumnoKinder();
                    break;
                case 6:
                    RegistrarNotasKinder();
                    break;
                case 7:
                    RegistrarAsistenciaKinder();
                    break;
                default:
                    if (opcion != 8)
                    {
                        Console.WriteLine("Opcion invalida.");
                        Pausar();
                    }
                    break;
            }
        } while (opcion != 8);
    }

    static void MenuEmpleados()
    {
        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine(". . . EMPLEADOS . . .");
            Console.WriteLine("1. Registrar empleado");
            Console.WriteLine("2. Editar empleado");
            Console.WriteLine("3. Eliminar empleado");
            Console.WriteLine("4. Mostrar empleados");
            Console.WriteLine("5. Buscar empleado por DUI");
            Console.WriteLine("6. Regresar");
            Console.Write("Seleccione una opcion: ");
            opcion = LeerEntero("");

            switch (opcion)
            {
                case 1:
                    RegistrarEmpleado();
                    break;
                case 2:
                    EditarEmpleado();
                    break;
                case 3:
                    EliminarEmpleado();
                    break;
                case 4:
                    MostrarEmpleados();
                    break;
                case 5:
                    BuscarEmpleado();
                    break;
                default:
                    if (opcion != 6)
                    {
                        Console.WriteLine("Opcion invalida.");
                        Pausar();
                    }
                    break;
            }
        } while (opcion != 6);
    }

    static void MenuFacultadesCarreras()
    {
        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine(". . . FACULTADES Y CARRERAS . . .");
            Console.WriteLine("1. Mostrar sedes");
            Console.WriteLine("2. Mostrar facultades por sede");
            Console.WriteLine("3. Mostrar carreras por sede y facultad");
            Console.WriteLine("4. Mostrar relacion sede - facultad - carrera");
            Console.WriteLine("5. Regresar");
            Console.Write("Seleccione una opcion: ");
            opcion = LeerEntero("");

            switch (opcion)
            {
                case 1:
                    MostrarSedes();
                    break;
                case 2:
                    MostrarFacultadesPorSede();
                    break;
                case 3:
                    MostrarCarrerasPorSedeFacultad();
                    break;
                case 4:
                    MostrarRelacionSedeFacultadCarrera();
                    break;
                default:
                    if (opcion != 5)
                    {
                        Console.WriteLine("Opcion invalida.");
                        Pausar();
                    }
                    break;
            }
        } while (opcion != 5);
    }

    static void MenuMateriasInscripciones()
    {
        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine(". . . MATERIAS E INSCRIPCIONES . . .");
            Console.WriteLine("1. Mostrar materias por carrera");
            Console.WriteLine("2. Inscribir o cambiar materias de estudiante");
            Console.WriteLine("3. Mostrar inscripcion de estudiante");
            Console.WriteLine("4. Regresar");
            Console.Write("Seleccione una opcion: ");
            opcion = LeerEntero("");

            switch (opcion)
            {
                case 1:
                    MostrarMateriasPorCarrera();
                    break;
                case 2:
                    CambiarMateriasAlumnoUniversitario();
                    break;
                case 3:
                    MostrarInscripcionUniversitaria();
                    break;
                default:
                    if (opcion != 4)
                    {
                        Console.WriteLine("Opcion invalida.");
                        Pausar();
                    }
                    break;
            }
        } while (opcion != 4);
    }

    static void MenuNotasAsistencia()
    {
        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine(". . . NOTAS Y ASISTENCIA . . .");
            Console.WriteLine("1. Registrar notas universitarias");
            Console.WriteLine("2. Editar notas universitarias");
            Console.WriteLine("3. Registrar asistencia universitaria");
            Console.WriteLine("4. Registrar notas de kinder");
            Console.WriteLine("5. Registrar asistencia de kinder");
            Console.WriteLine("6. Consultar estado academico universitario");
            Console.WriteLine("7. Regresar");
            Console.Write("Seleccione una opcion: ");
            opcion = LeerEntero("");

            switch (opcion)
            {
                case 1:
                    RegistrarNotasUniversitarias();
                    break;
                case 2:
                    EditarNotasUniversitarias();
                    break;
                case 3:
                    RegistrarAsistenciaUniversitaria();
                    break;
                case 4:
                    RegistrarNotasKinder();
                    break;
                case 5:
                    RegistrarAsistenciaKinder();
                    break;
                case 6:
                    ConsultarEstadoUniversitario();
                    break;
                default:
                    if (opcion != 7)
                    {
                        Console.WriteLine("Opcion invalida.");
                        Pausar();
                    }
                    break;
            }
        } while (opcion != 7);
    }

    static void MenuReportes()
    {
        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine(". . . REPORTES / CONSULTAS . . .");
            Console.WriteLine("1. Listado de alumnos universitarios");
            Console.WriteLine("2. Listado de alumnos de kinder");
            Console.WriteLine("3. Listado de empleados");
            Console.WriteLine("4. Estadisticas universitarias");
            Console.WriteLine("5. Estadisticas de kinder");
            Console.WriteLine("6. Decanos asignados");
            Console.WriteLine("7. Regresar");
            Console.Write("Seleccione una opcion: ");
            opcion = LeerEntero("");

            switch (opcion)
            {
                case 1:
                    MostrarAlumnosUniversitarios();
                    break;
                case 2:
                    MostrarAlumnosKinder();
                    break;
                case 3:
                    MostrarEmpleados();
                    break;
                case 4:
                    MostrarEstadisticasUniversitarias();
                    break;
                case 5:
                    MostrarEstadisticasKinder();
                    break;
                case 6:
                    MostrarDecanos();
                    break;
                default:
                    if (opcion != 7)
                    {
                        Console.WriteLine("Opcion invalida.");
                        Pausar();
                    }
                    break;
            }
        } while (opcion != 7);
    }

    // ALUMNOS UNIVERSITARIOS
    static void RegistrarAlumnoUniversitario()
    {
        Console.Clear();
        if (totalEstudiantesUni >= MAX_ESTUDIANTES_UNI)
        {
            Console.WriteLine("Ya se alcanzo el maximo de 50 estudiantes universitarios.");
            Pausar();
            return;
        }

        int sede = SeleccionarSede();
        if (sede == 0)
            return;

        if (ContarEstudiantesUniPorSede(sede) >= MAX_ESTUDIANTES_SEDE)
        {
            Console.WriteLine("Ya se alcanzo el maximo de 25 estudiantes en esta sede.");
            Pausar();
            return;
        }

        int facultad = SeleccionarFacultadPorSede(sede);
        if (facultad == 0)
            return;

        int carrera = SeleccionarCarreraPorSedeFacultad(sede, facultad);
        if (carrera == 0)
            return;

        int indice = totalEstudiantesUni;
        nombresUni[indice] = LeerNombreCompleto("Nombre y apellidos: ");
        carnetsUni[indice] = LeerCarnet("Carne: ", -1);
        edadesUni[indice] = LeerEdad("Edad: ", 16, 50);
        sedesUni[indice] = sede;
        facultadesUni[indice] = facultad;
        carrerasUni[indice] = carrera;

        InscribirMateriasAlumno(indice);

        totalEstudiantesUni++;
        Console.WriteLine("El registro ha sido guardado correctamente.");
        Pausar();
    }

    static void EditarAlumnoUniversitario()
    {
        int indice = SeleccionarEstudianteUniversitario();
        if (indice == -1)
            return;

        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine(". . . EDITAR ALUMNO UNIVERSITARIO . . .");
            Console.WriteLine("Alumno: " + nombresUni[indice]);
            Console.WriteLine("1. Editar nombre");
            Console.WriteLine("2. Editar carnet");
            Console.WriteLine("3. Editar edad");
            Console.WriteLine("4. Editar sede, facultad y carrera");
            Console.WriteLine("5. Editar materias inscritas");
            Console.WriteLine("6. Regresar");
            Console.Write("Seleccione una opcion: ");
            opcion = LeerEntero("");

            switch (opcion)
            {
                case 1:
                    nombresUni[indice] = LeerNombreCompleto("Nombre y apellidos: ");
                    Console.WriteLine("Dato actualizado correctamente.");
                    Pausar();
                    break;
                case 2:
                    carnetsUni[indice] = LeerCarnet("Carne: ", indice);
                    Console.WriteLine("Dato actualizado correctamente.");
                    Pausar();
                    break;
                case 3:
                    edadesUni[indice] = LeerEdad("Edad: ", 16, 50);
                    Console.WriteLine("Dato actualizado correctamente.");
                    Pausar();
                    break;
                case 4:
                    EditarCarreraAlumno(indice);
                    break;
                case 5:
                    InscribirMateriasAlumno(indice);
                    LimpiarNotasUniversidad(indice);
                    Console.WriteLine("Materias actualizadas correctamente.");
                    Pausar();
                    break;
                default:
                    if (opcion != 6)
                    {
                        Console.WriteLine("Opcion invalida.");
                        Pausar();
                    }
                    break;
            }
        } while (opcion != 6);
    }

    static void EditarCarreraAlumno(int indice)
    {
        int sedeNueva = SeleccionarSede();
        if (sedeNueva == 0)
            return;

        if (sedeNueva != sedesUni[indice] && ContarEstudiantesUniPorSede(sedeNueva) >= MAX_ESTUDIANTES_SEDE)
        {
            Console.WriteLine("Ya se alcanzo el maximo de estudiantes en esa sede.");
            Pausar();
            return;
        }

        int facultadNueva = SeleccionarFacultadPorSede(sedeNueva);
        if (facultadNueva == 0)
            return;

        int carreraNueva = SeleccionarCarreraPorSedeFacultad(sedeNueva, facultadNueva);
        if (carreraNueva == 0)
            return;

        sedesUni[indice] = sedeNueva;
        facultadesUni[indice] = facultadNueva;
        carrerasUni[indice] = carreraNueva;
        InscribirMateriasAlumno(indice);
        LimpiarNotasUniversidad(indice);
        LimpiarAsistenciaUniversidad(indice);
        Console.WriteLine("Dato actualizado correctamente.");
        Pausar();
    }

    static void EliminarAlumnoUniversitario()
    {
        int indice = SeleccionarEstudianteUniversitario();
        if (indice == -1)
            return;

        Console.Clear();
        Console.WriteLine("Alumno a eliminar: " + nombresUni[indice] + " - " + carnetsUni[indice]);
        string confirmar = LeerSiNo("Desea eliminar este registro? (SI/NO): ");
        if (confirmar != "SI")
        {
            Console.WriteLine("Eliminacion cancelada.");
            Pausar();
            return;
        }

        for (int i = indice; i < totalEstudiantesUni - 1; i++)
            CopiarAlumnoUniversitario(i, i + 1);

        totalEstudiantesUni--;
        LimpiarAlumnoUniversitario(totalEstudiantesUni);
        Console.WriteLine("Registro eliminado correctamente.");
        Pausar();
    }

    static void MostrarAlumnosUniversitarios()
    {
        Console.Clear();
        if (totalEstudiantesUni == 0)
        {
            Console.WriteLine("No hay estudiantes universitarios registrados.");
            Pausar();
            return;
        }

        Console.WriteLine(". . . LISTADO DE ALUMNOS UNIVERSITARIOS . . .");
        for (int i = 0; i < totalEstudiantesUni; i++)
        {
            MostrarDatosAlumnoUniversitario(i);
            Console.WriteLine("----------------------------------------");
        }
        Pausar();
    }

    static void BuscarAlumnoUniversitario()
    {
        Console.Clear();
        if (totalEstudiantesUni == 0)
        {
            Console.WriteLine("No hay estudiantes universitarios registrados.");
            Pausar();
            return;
        }

        Console.Write("Ingrese el carnet del estudiante: ");
        string buscado = (Console.ReadLine() ?? "").Trim().ToUpper();
        int indice = BuscarCarnet(buscado, -1);

        if (indice == -1)
            Console.WriteLine("No se encontro el estudiante.");
        else
            MostrarDatosAlumnoUniversitario(indice);

        Pausar();
    }

    static void CambiarMateriasAlumnoUniversitario()
    {
        int indice = SeleccionarEstudianteUniversitario();
        if (indice == -1)
            return;

        InscribirMateriasAlumno(indice);
        LimpiarNotasUniversidad(indice);
        Console.WriteLine("Materias actualizadas correctamente.");
        Pausar();
    }

    static void MostrarInscripcionUniversitaria()
    {
        int indice = SeleccionarEstudianteUniversitario();
        if (indice == -1)
            return;

        Console.Clear();
        Console.WriteLine(". . . INSCRIPCION DEL ESTUDIANTE . . .");
        Console.WriteLine("Nombre: " + nombresUni[indice]);
        Console.WriteLine("Carne: " + carnetsUni[indice]);
        Console.WriteLine("Sede: " + sedes[sedesUni[indice]]);
        Console.WriteLine("Facultad: " + facultades[facultadesUni[indice]]);
        Console.WriteLine("Carrera: " + carreras[facultadesUni[indice], carrerasUni[indice]]);
        Console.WriteLine();
        MostrarMateriasAlumno(indice);
        Pausar();
    }

    static void InscribirMateriasAlumno(int indice)
    {
        int[] disponibles = new int[20];
        int cantidadDisponibles = ObtenerMateriasPorCarrera(facultadesUni[indice], carrerasUni[indice], disponibles);
        int maximo = MAX_MATERIAS_ESTUDIANTE;

        if (cantidadDisponibles < maximo)
            maximo = cantidadDisponibles;

        Console.Clear();
        Console.WriteLine(". . . INSCRIPCION DE MATERIAS . . .");
        Console.WriteLine("Carrera: " + carreras[facultadesUni[indice], carrerasUni[indice]]);
        MostrarMateriasDisponibles(disponibles, cantidadDisponibles);

        int cantidad = LeerEnteroRango("Cantidad de materias a inscribir (1-" + maximo + "): ", 1, maximo);

        for (int i = 0; i < MAX_MATERIAS_ESTUDIANTE; i++)
            materiasUni[indice, i] = 0;

        cantidadMateriasUni[indice] = cantidad;

        for (int i = 0; i < cantidad; i++)
        {
            int seleccion;
            int idMateria;
            bool repetida;
            do
            {
                MostrarMateriasDisponibles(disponibles, cantidadDisponibles);
                seleccion = LeerEnteroRango("Seleccione la materia " + (i + 1) + ": ", 1, cantidadDisponibles);
                idMateria = disponibles[seleccion - 1];
                repetida = MateriaYaInscrita(indice, idMateria, i);
                if (repetida)
                    Console.WriteLine("Esa materia ya fue inscrita.");
            } while (repetida);

            materiasUni[indice, i] = idMateria;
        }
    }

    // NOTAS Y ASISTENCIA UNIVERSITARIA
    static void RegistrarNotasUniversitarias()
    {
        int estudiante = SeleccionarEstudianteUniversitario();
        if (estudiante == -1)
            return;

        if (cantidadMateriasUni[estudiante] == 0)
        {
            Console.WriteLine("El estudiante no tiene materias inscritas.");
            Pausar();
            return;
        }

        int materia = SeleccionarMateriaInscrita(estudiante);
        if (materia == -1)
            return;

        Console.Clear();
        Console.WriteLine(". . . REGISTRO DE NOTAS UNIVERSITARIAS . . .");
        Console.WriteLine("Alumno: " + nombresUni[estudiante]);
        Console.WriteLine("Materia: " + materias[materiasUni[estudiante, materia]]);

        for (int periodo = 0; periodo < PERIODOS; periodo++)
            RegistrarPeriodoUniversidad(estudiante, materia, periodo);

        Console.WriteLine("Promedio de la materia: " + PromedioMateriaUniversidad(estudiante, materia));
        Pausar();
    }

    static void EditarNotasUniversitarias()
    {
        int estudiante = SeleccionarEstudianteUniversitario();
        if (estudiante == -1)
            return;

        int materia = SeleccionarMateriaInscrita(estudiante);
        if (materia == -1)
            return;

        int periodo = LeerEnteroRango("Periodo a editar (1-3): ", 1, PERIODOS) - 1;
        RegistrarPeriodoUniversidad(estudiante, materia, periodo);
        Console.WriteLine("Promedio de la materia: " + PromedioMateriaUniversidad(estudiante, materia));
        Pausar();
    }

    static void RegistrarPeriodoUniversidad(int estudiante, int materia, int periodo)
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Periodo " + (periodo + 1));
        int cantidad = LeerEnteroRango("Cantidad de actividades (2-5): ", MIN_ACTIVIDADES, MAX_ACTIVIDADES);
        double sumaActividades = 0;

        cantidadActividadesUni[estudiante, materia, periodo] = cantidad;

        for (int i = 0; i < MAX_ACTIVIDADES; i++)
            actividadesUni[estudiante, materia, periodo, i] = 0;

        for (int i = 0; i < cantidad; i++)
        {
            actividadesUni[estudiante, materia, periodo, i] = LeerNota("Nota de actividad " + (i + 1) + ": ");
            sumaActividades += actividadesUni[estudiante, materia, periodo, i];
        }

        parcialesUni[estudiante, materia, periodo] = LeerNota("Nota del parcial: ");
        promediosPeriodosUni[estudiante, materia, periodo] = Math.Round((sumaActividades / cantidad * 0.5) + (parcialesUni[estudiante, materia, periodo] * 0.5), 2);
        notasRegistradasUni[estudiante, materia, periodo] = true;

        Console.WriteLine("Promedio del periodo: " + promediosPeriodosUni[estudiante, materia, periodo]);
    }

    static void RegistrarAsistenciaUniversitaria()
    {
        int estudiante = SeleccionarEstudianteUniversitario();
        if (estudiante == -1)
            return;

        Console.Clear();
        Console.WriteLine(". . . ASISTENCIA UNIVERSITARIA . . .");
        Console.WriteLine("Alumno: " + nombresUni[estudiante]);

        for (int periodo = 0; periodo < PERIODOS; periodo++)
        {
            Console.WriteLine("Periodo " + (periodo + 1));
            int total = LeerEnteroRango("Clases impartidas: ", 1, 300);
            int asistidas = LeerEnteroRango("Clases asistidas: ", 0, total);
            clasesTotalesUni[estudiante, periodo] = total;
            clasesAsistidasUni[estudiante, periodo] = asistidas;
        }

        Console.WriteLine("Porcentaje de asistencia: " + PorcentajeAsistenciaUniversidad(estudiante) + "%");
        Pausar();
    }

    static void ConsultarEstadoUniversitario()
    {
        int estudiante = SeleccionarEstudianteUniversitario();
        if (estudiante == -1)
            return;

        Console.Clear();
        MostrarDatosAlumnoUniversitario(estudiante);
        Pausar();
    }

    // ALUMNOS KINDER
    static void RegistrarAlumnoKinder()
    {
        Console.Clear();
        if (totalEstudiantesKinder >= MAX_ESTUDIANTES_KINDER)
        {
            Console.WriteLine("Ya se alcanzo el maximo de 30 alumnos de kinder.");
            Pausar();
            return;
        }

        int sede = SeleccionarSede();
        if (sede == 0)
            return;

        if (sede != 1)
        {
            Console.WriteLine("El kinder solo esta disponible en Santa Ana.");
            Pausar();
            return;
        }

        int nivel = SeleccionarNivelKinder();
        if (nivel == 0)
            return;

        if (ContarKinderPorNivel(nivel) >= MAX_ESTUDIANTES_KINDER_NIVEL)
        {
            Console.WriteLine("Ya se alcanzo el maximo de 10 alumnos en este nivel.");
            Pausar();
            return;
        }

        int indice = totalEstudiantesKinder;
        nombresKinder[indice] = LeerNombreCompleto("Nombre y apellidos: ");
        niesKinder[indice] = GenerarNIE();
        edadesKinder[indice] = LeerEdad("Edad: ", 3, 7);
        enfermedadKinder[indice] = LeerSiNo("Enfermedad cronica? (SI/NO): ");
        discapacidadKinder[indice] = LeerSiNo("Discapacidad? (SI/NO): ");
        nivelesKinderEst[indice] = nivel;
        totalEstudiantesKinder++;

        Console.WriteLine("Alumno de kinder registrado correctamente.");
        Console.WriteLine("NIE generado: " + niesKinder[indice]);
        Pausar();
    }

    static void EditarAlumnoKinder()
    {
        int indice = SeleccionarEstudianteKinder();
        if (indice == -1)
            return;

        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine(". . . EDITAR ALUMNO DE KINDER . . .");
            Console.WriteLine("Alumno: " + nombresKinder[indice]);
            Console.WriteLine("1. Editar nombre");
            Console.WriteLine("2. Editar edad");
            Console.WriteLine("3. Editar enfermedad cronica");
            Console.WriteLine("4. Editar discapacidad");
            Console.WriteLine("5. Editar nivel");
            Console.WriteLine("6. Regresar");
            Console.Write("Seleccione una opcion: ");
            opcion = LeerEntero("");

            switch (opcion)
            {
                case 1:
                    nombresKinder[indice] = LeerNombreCompleto("Nombre y apellidos: ");
                    Console.WriteLine("Dato actualizado correctamente.");
                    Pausar();
                    break;
                case 2:
                    edadesKinder[indice] = LeerEdad("Edad: ", 3, 7);
                    Console.WriteLine("Dato actualizado correctamente.");
                    Pausar();
                    break;
                case 3:
                    enfermedadKinder[indice] = LeerSiNo("Enfermedad cronica? (SI/NO): ");
                    Console.WriteLine("Dato actualizado correctamente.");
                    Pausar();
                    break;
                case 4:
                    discapacidadKinder[indice] = LeerSiNo("Discapacidad? (SI/NO): ");
                    Console.WriteLine("Dato actualizado correctamente.");
                    Pausar();
                    break;
                case 5:
                    EditarNivelKinder(indice);
                    break;
                default:
                    if (opcion != 6)
                    {
                        Console.WriteLine("Opcion invalida.");
                        Pausar();
                    }
                    break;
            }
        } while (opcion != 6);
    }

    static void EditarNivelKinder(int indice)
    {
        int nivel = SeleccionarNivelKinder();
        if (nivel == 0)
            return;

        if (nivel != nivelesKinderEst[indice] && ContarKinderPorNivel(nivel) >= MAX_ESTUDIANTES_KINDER_NIVEL)
        {
            Console.WriteLine("Ya se alcanzo el maximo de alumnos en ese nivel.");
            Pausar();
            return;
        }

        nivelesKinderEst[indice] = nivel;
        Console.WriteLine("Dato actualizado correctamente.");
        Pausar();
    }

    static void EliminarAlumnoKinder()
    {
        int indice = SeleccionarEstudianteKinder();
        if (indice == -1)
            return;

        Console.Clear();
        Console.WriteLine("Alumno a eliminar: " + nombresKinder[indice] + " - " + niesKinder[indice]);
        string confirmar = LeerSiNo("Desea eliminar este registro? (SI/NO): ");
        if (confirmar != "SI")
        {
            Console.WriteLine("Eliminacion cancelada.");
            Pausar();
            return;
        }

        for (int i = indice; i < totalEstudiantesKinder - 1; i++)
            CopiarAlumnoKinder(i, i + 1);

        totalEstudiantesKinder--;
        LimpiarAlumnoKinder(totalEstudiantesKinder);
        Console.WriteLine("Registro eliminado correctamente.");
        Pausar();
    }

    static void MostrarAlumnosKinder()
    {
        Console.Clear();
        if (totalEstudiantesKinder == 0)
        {
            Console.WriteLine("No hay alumnos de kinder registrados.");
            Pausar();
            return;
        }

        Console.WriteLine(". . . LISTADO DE ALUMNOS DE KINDER . . .");
        for (int i = 0; i < totalEstudiantesKinder; i++)
        {
            MostrarDatosAlumnoKinder(i);
            Console.WriteLine("----------------------------------------");
        }
        Pausar();
    }

    static void BuscarAlumnoKinder()
    {
        Console.Clear();
        if (totalEstudiantesKinder == 0)
        {
            Console.WriteLine("No hay alumnos de kinder registrados.");
            Pausar();
            return;
        }

        Console.Write("Ingrese el NIE: ");
        string buscado = (Console.ReadLine() ?? "").Trim().ToUpper();
        int indice = BuscarNIE(buscado);

        if (indice == -1)
            Console.WriteLine("No se encontro el alumno.");
        else
            MostrarDatosAlumnoKinder(indice);

        Pausar();
    }

    static void RegistrarNotasKinder()
    {
        int indice = SeleccionarEstudianteKinder();
        if (indice == -1)
            return;

        Console.Clear();
        Console.WriteLine(". . . NOTAS DE KINDER . . .");
        Console.WriteLine("Alumno: " + nombresKinder[indice]);

        for (int i = 0; i < PERIODOS; i++)
        {
            notasKinder[indice, i] = LeerNota("Nota " + (i + 1) + ": ");
            notasRegistradasKinder[indice, i] = true;
        }

        Console.WriteLine("Promedio: " + PromedioKinder(indice));
        Pausar();
    }

    static void RegistrarAsistenciaKinder()
    {
        int indice = SeleccionarEstudianteKinder();
        if (indice == -1)
            return;

        Console.Clear();
        Console.WriteLine(". . . ASISTENCIA DE KINDER . . .");
        Console.WriteLine("Alumno: " + nombresKinder[indice]);
        clasesTotalesKinder[indice] = LeerEnteroRango("Clases impartidas: ", 1, 300);
        clasesAsistidasKinder[indice] = LeerEnteroRango("Clases asistidas: ", 0, clasesTotalesKinder[indice]);
        Console.WriteLine("Porcentaje de asistencia: " + PorcentajeAsistenciaKinder(indice) + "%");
        Pausar();
    }

    // EMPLEADOS
    static void RegistrarEmpleado()
    {
        Console.Clear();
        if (totalEmpleados >= MAX_EMPLEADOS)
        {
            Console.WriteLine("Ya se alcanzo el maximo de 50 empleados.");
            Pausar();
            return;
        }

        int cargo = SeleccionarCargo();
        if (cargo == 0)
            return;

        if (!CargoDisponible(cargo))
        {
            Console.WriteLine("Ya se alcanzo el limite para ese cargo.");
            Pausar();
            return;
        }

        int indice = totalEmpleados;
        cargoEmpleado[indice] = cargo;
        nombresEmpleado[indice] = LeerNombreSimple("Nombres: ");
        apellidosEmpleado[indice] = LeerNombreSimple("Apellidos: ");
        duiEmpleado[indice] = LeerDUI("DUI: ", -1);
        edadEmpleado[indice] = LeerEdad("Edad: ", 18, 50);
        contactoEmpleado[indice] = LeerContacto("Telefono o contacto: ");
        estadoEmpleado[indice] = SeleccionarEstadoLaboral();

        if (cargo == 1)
            RegistrarDatosDocenteUniversitario(indice);
        else if (cargo == 2)
            RegistrarDatosDocenteKinder(indice);
        else if (cargo == 3)
            RegistrarDatosDecano(indice);
        else
            RegistrarSedeEmpleado(indice);

        if (cargoEmpleado[indice] == 0)
        {
            Console.WriteLine("Registro cancelado.");
            Pausar();
            return;
        }

        totalEmpleados++;
        SumarCargo(cargo);
        Console.WriteLine("Empleado registrado correctamente.");
        Pausar();
    }

    static void RegistrarSedeEmpleado(int indice)
    {
        int sede = SeleccionarSede();
        if (sede == 0)
        {
            cargoEmpleado[indice] = 0;
            return;
        }
        sedeEmpleado[indice] = sede;
    }

    static void RegistrarDatosDocenteUniversitario(int indice)
    {
        int sede = SeleccionarSede();
        if (sede == 0)
        {
            cargoEmpleado[indice] = 0;
            return;
        }

        int facultad = SeleccionarFacultadPorSede(sede);
        if (facultad == 0)
        {
            cargoEmpleado[indice] = 0;
            return;
        }

        int carrera = SeleccionarCarreraPorSedeFacultad(sede, facultad);
        if (carrera == 0)
        {
            cargoEmpleado[indice] = 0;
            return;
        }

        sedeEmpleado[indice] = sede;
        facultadEmpleado[indice] = facultad;
        carreraEmpleado[indice] = carrera;
        InscribirMateriasDocente(indice);
    }

    static void RegistrarDatosDocenteKinder(int indice)
    {
        int sede = SeleccionarSede();
        if (sede == 0)
        {
            cargoEmpleado[indice] = 0;
            return;
        }

        if (sede != 1)
        {
            Console.WriteLine("El docente de kinder solo puede pertenecer a Santa Ana.");
            cargoEmpleado[indice] = 0;
            return;
        }

        sedeEmpleado[indice] = 1;
        nivelDocenteKinder[indice] = SeleccionarNivelKinder();
        if (nivelDocenteKinder[indice] == 0)
            cargoEmpleado[indice] = 0;
    }

    static void RegistrarDatosDecano(int indice)
    {
        int facultad = SeleccionarFacultadDecano();
        if (facultad == 0)
        {
            cargoEmpleado[indice] = 0;
            return;
        }

        if (facultadTieneDecano[facultad])
        {
            Console.WriteLine("Esta facultad ya tiene decano asignado.");
            cargoEmpleado[indice] = 0;
            return;
        }

        int sede = SeleccionarSede();
        if (sede == 0)
        {
            cargoEmpleado[indice] = 0;
            return;
        }

        sedeEmpleado[indice] = sede;
        facultadEmpleado[indice] = facultad;
        facultadTieneDecano[facultad] = true;
        decanoEmpleado[facultad] = indice;
    }

    static void InscribirMateriasDocente(int indice)
    {
        int[] disponibles = new int[20];
        int cantidadDisponibles = ObtenerMateriasPorCarrera(facultadEmpleado[indice], carreraEmpleado[indice], disponibles);
        int maximo = MAX_MATERIAS_DOCENTE;

        if (cantidadDisponibles < maximo)
            maximo = cantidadDisponibles;

        Console.Clear();
        Console.WriteLine(". . . MATERIAS DEL DOCENTE . . .");
        Console.WriteLine("Carrera: " + carreras[facultadEmpleado[indice], carreraEmpleado[indice]]);
        MostrarMateriasDisponibles(disponibles, cantidadDisponibles);

        int cantidad = LeerEnteroRango("Cantidad de materias que impartira (1-" + maximo + "): ", 1, maximo);
        cantidadMateriasDocenteUni[indice] = cantidad;

        for (int i = 0; i < MAX_MATERIAS_DOCENTE; i++)
            materiasDocenteUni[indice, i] = 0;

        for (int i = 0; i < cantidad; i++)
        {
            int seleccion;
            int idMateria;
            bool repetida;
            do
            {
                MostrarMateriasDisponibles(disponibles, cantidadDisponibles);
                seleccion = LeerEnteroRango("Seleccione la materia " + (i + 1) + ": ", 1, cantidadDisponibles);
                idMateria = disponibles[seleccion - 1];
                repetida = MateriaYaAsignadaDocente(indice, idMateria, i);
                if (repetida)
                    Console.WriteLine("Esa materia ya fue asignada.");
            } while (repetida);

            materiasDocenteUni[indice, i] = idMateria;
        }
    }

    static void EditarEmpleado()
    {
        int indice = SeleccionarEmpleado();
        if (indice == -1)
            return;

        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine(". . . EDITAR EMPLEADO . . .");
            Console.WriteLine("Empleado: " + nombresEmpleado[indice] + " " + apellidosEmpleado[indice]);
            Console.WriteLine("1. Editar nombres");
            Console.WriteLine("2. Editar apellidos");
            Console.WriteLine("3. Editar DUI");
            Console.WriteLine("4. Editar edad");
            Console.WriteLine("5. Editar contacto");
            Console.WriteLine("6. Editar estado laboral");
            Console.WriteLine("7. Editar datos del cargo");
            Console.WriteLine("8. Regresar");
            Console.Write("Seleccione una opcion: ");
            opcion = LeerEntero("");

            switch (opcion)
            {
                case 1:
                    nombresEmpleado[indice] = LeerNombreSimple("Nombres: ");
                    Console.WriteLine("Dato actualizado correctamente.");
                    Pausar();
                    break;
                case 2:
                    apellidosEmpleado[indice] = LeerNombreSimple("Apellidos: ");
                    Console.WriteLine("Dato actualizado correctamente.");
                    Pausar();
                    break;
                case 3:
                    duiEmpleado[indice] = LeerDUI("DUI: ", indice);
                    Console.WriteLine("Dato actualizado correctamente.");
                    Pausar();
                    break;
                case 4:
                    edadEmpleado[indice] = LeerEdad("Edad: ", 18, 50);
                    Console.WriteLine("Dato actualizado correctamente.");
                    Pausar();
                    break;
                case 5:
                    contactoEmpleado[indice] = LeerContacto("Telefono o contacto: ");
                    Console.WriteLine("Dato actualizado correctamente.");
                    Pausar();
                    break;
                case 6:
                    estadoEmpleado[indice] = SeleccionarEstadoLaboral();
                    Console.WriteLine("Dato actualizado correctamente.");
                    Pausar();
                    break;
                case 7:
                    EditarDatosCargoEmpleado(indice);
                    break;
                default:
                    if (opcion != 8)
                    {
                        Console.WriteLine("Opcion invalida.");
                        Pausar();
                    }
                    break;
            }
        } while (opcion != 8);
    }

    static void EditarDatosCargoEmpleado(int indice)
    {
        if (cargoEmpleado[indice] == 1)
        {
            RegistrarDatosDocenteUniversitario(indice);
            Console.WriteLine("Dato actualizado correctamente.");
        }
        else if (cargoEmpleado[indice] == 2)
        {
            RegistrarDatosDocenteKinder(indice);
            Console.WriteLine("Dato actualizado correctamente.");
        }
        else if (cargoEmpleado[indice] == 3)
        {
            int facultadAnterior = facultadEmpleado[indice];
            facultadTieneDecano[facultadAnterior] = false;
            decanoEmpleado[facultadAnterior] = -1;
            RegistrarDatosDecano(indice);
            if (cargoEmpleado[indice] == 0)
            {
                cargoEmpleado[indice] = 3;
                facultadTieneDecano[facultadAnterior] = true;
                decanoEmpleado[facultadAnterior] = indice;
            }
            Console.WriteLine("Dato actualizado correctamente.");
        }
        else
        {
            RegistrarSedeEmpleado(indice);
            Console.WriteLine("Dato actualizado correctamente.");
        }

        Pausar();
    }

    static void EliminarEmpleado()
    {
        int indice = SeleccionarEmpleado();
        if (indice == -1)
            return;

        Console.Clear();
        Console.WriteLine("Empleado a eliminar: " + nombresEmpleado[indice] + " " + apellidosEmpleado[indice]);
        string confirmar = LeerSiNo("Desea eliminar este registro? (SI/NO): ");
        if (confirmar != "SI")
        {
            Console.WriteLine("Eliminacion cancelada.");
            Pausar();
            return;
        }

        RestarCargo(cargoEmpleado[indice]);

        if (cargoEmpleado[indice] == 3)
        {
            facultadTieneDecano[facultadEmpleado[indice]] = false;
            decanoEmpleado[facultadEmpleado[indice]] = -1;
        }

        for (int i = indice; i < totalEmpleados - 1; i++)
            CopiarEmpleado(i, i + 1);

        totalEmpleados--;
        LimpiarEmpleado(totalEmpleados);
        AjustarIndicesDecanos(indice);
        Console.WriteLine("Registro eliminado correctamente.");
        Pausar();
    }

    static void MostrarEmpleados()
    {
        Console.Clear();
        if (totalEmpleados == 0)
        {
            Console.WriteLine("No hay empleados registrados.");
            Pausar();
            return;
        }

        Console.WriteLine(". . . LISTADO DE EMPLEADOS . . .");
        for (int i = 0; i < totalEmpleados; i++)
        {
            MostrarDatosEmpleado(i);
            Console.WriteLine("----------------------------------------");
        }
        Pausar();
    }

    static void BuscarEmpleado()
    {
        Console.Clear();
        if (totalEmpleados == 0)
        {
            Console.WriteLine("No hay empleados registrados.");
            Pausar();
            return;
        }

        Console.Write("Ingrese el DUI: ");
        string buscado = (Console.ReadLine() ?? "").Trim();
        int indice = BuscarDUI(buscado, -1);

        if (indice == -1)
            Console.WriteLine("No se encontro el empleado.");
        else
            MostrarDatosEmpleado(indice);

        Pausar();
    }

    // FACULTADES Y CARRERAS
    static void MostrarSedes()
    {
        Console.Clear();
        Console.WriteLine(". . . SEDES . . .");
        Console.WriteLine("1. Santa Ana");
        Console.WriteLine("2. Ilobasco");
        Console.WriteLine("Kinder Madre de El Salvador: Disponible solo en Santa Ana");
        Pausar();
    }

    static void MostrarFacultadesPorSede()
    {
        int sede = SeleccionarSede();
        if (sede == 0)
            return;

        Console.Clear();
        Console.WriteLine(". . . FACULTADES EN " + sedes[sede].ToUpper() + " . . .");
        bool[] mostrada = new bool[6];

        for (int i = 0; i < relacionSede.Length; i++)
        {
            if (relacionSede[i] == sede && !mostrada[relacionFacultad[i]])
            {
                Console.WriteLine("- " + facultades[relacionFacultad[i]]);
                mostrada[relacionFacultad[i]] = true;
            }
        }
        Pausar();
    }

    static void MostrarCarrerasPorSedeFacultad()
    {
        int sede = SeleccionarSede();
        if (sede == 0)
            return;

        int facultad = SeleccionarFacultadPorSede(sede);
        if (facultad == 0)
            return;

        Console.Clear();
        Console.WriteLine(". . . CARRERAS . . .");
        Console.WriteLine("Sede: " + sedes[sede]);
        Console.WriteLine("Facultad: " + facultades[facultad]);

        for (int i = 0; i < relacionSede.Length; i++)
            if (relacionSede[i] == sede && relacionFacultad[i] == facultad)
                Console.WriteLine("- " + carreras[facultad, relacionCarrera[i]]);

        Pausar();
    }

    static void MostrarRelacionSedeFacultadCarrera()
    {
        Console.Clear();
        Console.WriteLine(". . . RELACION SEDE - FACULTAD - CARRERA . . .");
        for (int i = 0; i < relacionSede.Length; i++)
            Console.WriteLine(sedes[relacionSede[i]] + " | " + facultades[relacionFacultad[i]] + " | " + carreras[relacionFacultad[i], relacionCarrera[i]]);

        Pausar();
    }

    // MATERIAS
    static void MostrarMateriasPorCarrera()
    {
        int sede = SeleccionarSede();
        if (sede == 0)
            return;

        int facultad = SeleccionarFacultadPorSede(sede);
        if (facultad == 0)
            return;

        int carrera = SeleccionarCarreraPorSedeFacultad(sede, facultad);
        if (carrera == 0)
            return;

        int[] disponibles = new int[20];
        int cantidad = ObtenerMateriasPorCarrera(facultad, carrera, disponibles);

        Console.Clear();
        Console.WriteLine(". . . MATERIAS POR CARRERA . . .");
        Console.WriteLine("Sede: " + sedes[sede]);
        Console.WriteLine("Facultad: " + facultades[facultad]);
        Console.WriteLine("Carrera: " + carreras[facultad, carrera]);
        MostrarMateriasDisponibles(disponibles, cantidad);
        Pausar();
    }

    // REPORTES
    static void MostrarEstadisticasUniversitarias()
    {
        Console.Clear();
        Console.WriteLine(". . . ESTADISTICAS UNIVERSITARIAS . . .");

        if (totalEstudiantesUni == 0)
        {
            Console.WriteLine("No hay estudiantes universitarios registrados.");
            Pausar();
            return;
        }

        Console.WriteLine("Total de estudiantes: " + totalEstudiantesUni);
        Console.WriteLine("Santa Ana: " + ContarEstudiantesUniPorSede(1));
        Console.WriteLine("Ilobasco: " + ContarEstudiantesUniPorSede(2));
        Console.WriteLine();

        int conNotas = 0;
        int aprobadosNota = 0;
        int reprobadosNota = 0;
        int conAsistencia = 0;
        int aprobadosAsistencia = 0;
        int reprobadosAsistencia = 0;
        double sumaPromedios = 0;

        for (int i = 0; i < totalEstudiantesUni; i++)
        {
            if (NotasEstudianteUniversidadCompletas(i))
            {
                double promedio = PromedioEstudianteUniversidad(i);
                sumaPromedios += promedio;
                conNotas++;
                if (promedio >= 6.0)
                    aprobadosNota++;
                else
                    reprobadosNota++;
            }

            if (AsistenciaUniversidadRegistrada(i))
            {
                conAsistencia++;
                if (PorcentajeAsistenciaUniversidad(i) >= 75)
                    aprobadosAsistencia++;
                else
                    reprobadosAsistencia++;
            }
        }

        if (conNotas > 0)
            Console.WriteLine("Promedio general: " + Math.Round(sumaPromedios / conNotas, 2));
        else
            Console.WriteLine("Promedio general: Pendiente");

        Console.WriteLine("Aprobados por nota: " + aprobadosNota);
        Console.WriteLine("Reprobados por nota: " + reprobadosNota);
        Console.WriteLine("Aprobados por asistencia: " + aprobadosAsistencia);
        Console.WriteLine("Reprobados por asistencia: " + reprobadosAsistencia);
        Pausar();
    }

    static void MostrarEstadisticasKinder()
    {
        Console.Clear();
        Console.WriteLine(". . . ESTADISTICAS DE KINDER . . .");

        if (totalEstudiantesKinder == 0)
        {
            Console.WriteLine("No hay alumnos de kinder registrados.");
            Pausar();
            return;
        }

        Console.WriteLine("Total de alumnos: " + totalEstudiantesKinder);
        Console.WriteLine("Kinder 4: " + ContarKinderPorNivel(1));
        Console.WriteLine("Kinder 5: " + ContarKinderPorNivel(2));
        Console.WriteLine("Kinder 6: " + ContarKinderPorNivel(3));
        Console.WriteLine();

        int conNotas = 0;
        int aprobadosNota = 0;
        int reprobadosNota = 0;
        int conAsistencia = 0;
        int aprobadosAsistencia = 0;
        int reprobadosAsistencia = 0;
        double sumaPromedios = 0;

        for (int i = 0; i < totalEstudiantesKinder; i++)
        {
            if (NotasKinderCompletas(i))
            {
                double promedio = PromedioKinder(i);
                sumaPromedios += promedio;
                conNotas++;
                if (promedio >= 6.0)
                    aprobadosNota++;
                else
                    reprobadosNota++;
            }

            if (clasesTotalesKinder[i] > 0)
            {
                conAsistencia++;
                if (PorcentajeAsistenciaKinder(i) >= 75)
                    aprobadosAsistencia++;
                else
                    reprobadosAsistencia++;
            }
        }

        if (conNotas > 0)
            Console.WriteLine("Promedio general: " + Math.Round(sumaPromedios / conNotas, 2));
        else
            Console.WriteLine("Promedio general: Pendiente");

        Console.WriteLine("Aprobados por nota: " + aprobadosNota);
        Console.WriteLine("Reprobados por nota: " + reprobadosNota);
        Console.WriteLine("Aprobados por asistencia: " + aprobadosAsistencia);
        Console.WriteLine("Reprobados por asistencia: " + reprobadosAsistencia);
        Pausar();
    }

    static void MostrarDecanos()
    {
        Console.Clear();
        Console.WriteLine(". . . DECANOS ASIGNADOS . . .");
        for (int i = 1; i <= 4; i++)
        {
            Console.WriteLine("Facultad: " + facultades[i]);
            if (facultadTieneDecano[i])
            {
                int empleado = decanoEmpleado[i];
                Console.WriteLine("Decano: " + nombresEmpleado[empleado] + " " + apellidosEmpleado[empleado]);
                Console.WriteLine("DUI: " + duiEmpleado[empleado]);
            }
            else
            {
                Console.WriteLine("Decano: No asignado");
            }
            Console.WriteLine("----------------------------------------");
        }
        Pausar();
    }

    // SELECCIONES
    static int SeleccionarSede()
    {
        int opcion;
        do
        {
            Console.WriteLine(". . . SELECCIONE LA SEDE . . .");
            Console.WriteLine("1. Santa Ana");
            Console.WriteLine("2. Ilobasco");
            Console.WriteLine("3. Regresar");
            Console.Write("Seleccione una opcion: ");
            opcion = LeerEntero("");
            if (opcion < 1 || opcion > 3)
                Console.WriteLine("Opcion invalida.");
        } while (opcion < 1 || opcion > 3);

        if (opcion == 3)
            return 0;

        return opcion;
    }

    static int SeleccionarFacultadPorSede(int sede)
    {
        int[] opciones = new int[6];
        int cantidad = 0;

        for (int i = 0; i < relacionSede.Length; i++)
        {
            if (relacionSede[i] == sede && !ExisteEnVector(opciones, cantidad, relacionFacultad[i]))
            {
                opciones[cantidad] = relacionFacultad[i];
                cantidad++;
            }
        }

        int opcion;
        do
        {
            Console.WriteLine(". . . SELECCIONE LA FACULTAD . . .");
            for (int i = 0; i < cantidad; i++)
                Console.WriteLine((i + 1) + ". " + facultades[opciones[i]]);
            Console.WriteLine((cantidad + 1) + ". Regresar");
            Console.Write("Seleccione una opcion: ");
            opcion = LeerEntero("");
            if (opcion < 1 || opcion > cantidad + 1)
                Console.WriteLine("Opcion invalida.");
        } while (opcion < 1 || opcion > cantidad + 1);

        if (opcion == cantidad + 1)
            return 0;

        return opciones[opcion - 1];
    }

    static int SeleccionarCarreraPorSedeFacultad(int sede, int facultad)
    {
        int[] opciones = new int[4];
        int cantidad = 0;

        for (int i = 0; i < relacionSede.Length; i++)
        {
            if (relacionSede[i] == sede && relacionFacultad[i] == facultad && !ExisteEnVector(opciones, cantidad, relacionCarrera[i]))
            {
                opciones[cantidad] = relacionCarrera[i];
                cantidad++;
            }
        }

        int opcion;
        do
        {
            Console.WriteLine(". . . SELECCIONE LA CARRERA . . .");
            for (int i = 0; i < cantidad; i++)
                Console.WriteLine((i + 1) + ". " + carreras[facultad, opciones[i]]);
            Console.WriteLine((cantidad + 1) + ". Regresar");
            Console.Write("Seleccione una opcion: ");
            opcion = LeerEntero("");
            if (opcion < 1 || opcion > cantidad + 1)
                Console.WriteLine("Opcion invalida.");
        } while (opcion < 1 || opcion > cantidad + 1);

        if (opcion == cantidad + 1)
            return 0;

        return opciones[opcion - 1];
    }

    static int SeleccionarFacultadDecano()
    {
        int opcion;
        do
        {
            Console.WriteLine(". . . SELECCIONE LA FACULTAD . . .");
            for (int i = 1; i <= 4; i++)
                Console.WriteLine(i + ". " + facultades[i]);
            Console.WriteLine("5. Regresar");
            Console.Write("Seleccione una opcion: ");
            opcion = LeerEntero("");
            if (opcion < 1 || opcion > 5)
                Console.WriteLine("Opcion invalida.");
        } while (opcion < 1 || opcion > 5);

        if (opcion == 5)
            return 0;

        return opcion;
    }

    static int SeleccionarNivelKinder()
    {
        int opcion;
        do
        {
            Console.WriteLine(". . . SELECCIONE EL NIVEL . . .");
            Console.WriteLine("1. Kinder 4");
            Console.WriteLine("2. Kinder 5");
            Console.WriteLine("3. Kinder 6");
            Console.WriteLine("4. Regresar");
            Console.Write("Seleccione una opcion: ");
            opcion = LeerEntero("");
            if (opcion < 1 || opcion > 4)
                Console.WriteLine("Opcion invalida.");
        } while (opcion < 1 || opcion > 4);

        if (opcion == 4)
            return 0;

        return opcion;
    }

    static int SeleccionarCargo()
    {
        int opcion;
        do
        {
            Console.WriteLine(". . . SELECCIONE EL CARGO . . .");
            Console.WriteLine("1. Docente universitario");
            Console.WriteLine("2. Docente de kinder");
            Console.WriteLine("3. Decano");
            Console.WriteLine("4. Administrativo");
            Console.WriteLine("5. Ordenanza");
            Console.WriteLine("6. Vigilante");
            Console.WriteLine("7. Regresar");
            Console.Write("Seleccione una opcion: ");
            opcion = LeerEntero("");
            if (opcion < 1 || opcion > 7)
                Console.WriteLine("Opcion invalida.");
        } while (opcion < 1 || opcion > 7);

        if (opcion == 7)
            return 0;

        return opcion;
    }

    static int SeleccionarEstadoLaboral()
    {
        int opcion;
        do
        {
            Console.WriteLine(". . . ESTADO LABORAL . . .");
            Console.WriteLine("1. Activo");
            Console.WriteLine("2. Incapacidad");
            Console.WriteLine("3. Vacaciones");
            Console.Write("Seleccione una opcion: ");
            opcion = LeerEntero("");
            if (opcion < 1 || opcion > 3)
                Console.WriteLine("Opcion invalida.");
        } while (opcion < 1 || opcion > 3);

        return opcion;
    }

    static int SeleccionarEstudianteUniversitario()
    {
        if (totalEstudiantesUni == 0)
        {
            Console.WriteLine("No hay estudiantes universitarios registrados.");
            Pausar();
            return -1;
        }

        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine(". . . SELECCIONE EL ESTUDIANTE . . .");
            for (int i = 0; i < totalEstudiantesUni; i++)
                Console.WriteLine((i + 1) + ". " + carnetsUni[i] + " - " + nombresUni[i] + " - " + sedes[sedesUni[i]]);
            Console.WriteLine((totalEstudiantesUni + 1) + ". Regresar");
            Console.Write("Seleccione una opcion: ");
            opcion = LeerEntero("");
            if (opcion < 1 || opcion > totalEstudiantesUni + 1)
                Console.WriteLine("Opcion invalida.");
        } while (opcion < 1 || opcion > totalEstudiantesUni + 1);

        if (opcion == totalEstudiantesUni + 1)
            return -1;

        return opcion - 1;
    }

    static int SeleccionarEstudianteKinder()
    {
        if (totalEstudiantesKinder == 0)
        {
            Console.WriteLine("No hay alumnos de kinder registrados.");
            Pausar();
            return -1;
        }

        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine(". . . SELECCIONE EL ALUMNO . . .");
            for (int i = 0; i < totalEstudiantesKinder; i++)
                Console.WriteLine((i + 1) + ". " + niesKinder[i] + " - " + nombresKinder[i] + " - " + nivelesKinder[nivelesKinderEst[i]]);
            Console.WriteLine((totalEstudiantesKinder + 1) + ". Regresar");
            Console.Write("Seleccione una opcion: ");
            opcion = LeerEntero("");
            if (opcion < 1 || opcion > totalEstudiantesKinder + 1)
                Console.WriteLine("Opcion invalida.");
        } while (opcion < 1 || opcion > totalEstudiantesKinder + 1);

        if (opcion == totalEstudiantesKinder + 1)
            return -1;

        return opcion - 1;
    }

    static int SeleccionarEmpleado()
    {
        if (totalEmpleados == 0)
        {
            Console.WriteLine("No hay empleados registrados.");
            Pausar();
            return -1;
        }

        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine(". . . SELECCIONE EL EMPLEADO . . .");
            for (int i = 0; i < totalEmpleados; i++)
                Console.WriteLine((i + 1) + ". " + duiEmpleado[i] + " - " + nombresEmpleado[i] + " " + apellidosEmpleado[i] + " - " + cargos[cargoEmpleado[i]]);
            Console.WriteLine((totalEmpleados + 1) + ". Regresar");
            Console.Write("Seleccione una opcion: ");
            opcion = LeerEntero("");
            if (opcion < 1 || opcion > totalEmpleados + 1)
                Console.WriteLine("Opcion invalida.");
        } while (opcion < 1 || opcion > totalEmpleados + 1);

        if (opcion == totalEmpleados + 1)
            return -1;

        return opcion - 1;
    }

    static int SeleccionarMateriaInscrita(int estudiante)
    {
        int opcion;
        do
        {
            Console.WriteLine(". . . SELECCIONE LA MATERIA . . .");
            for (int i = 0; i < cantidadMateriasUni[estudiante]; i++)
                Console.WriteLine((i + 1) + ". " + materias[materiasUni[estudiante, i]]);
            Console.WriteLine((cantidadMateriasUni[estudiante] + 1) + ". Regresar");
            Console.Write("Seleccione una opcion: ");
            opcion = LeerEntero("");
            if (opcion < 1 || opcion > cantidadMateriasUni[estudiante] + 1)
                Console.WriteLine("Opcion invalida.");
        } while (opcion < 1 || opcion > cantidadMateriasUni[estudiante] + 1);

        if (opcion == cantidadMateriasUni[estudiante] + 1)
            return -1;

        return opcion - 1;
    }

    // MOSTRAR DATOS
    static void MostrarDatosAlumnoUniversitario(int i)
    {
        Console.WriteLine("========================================");
        Console.WriteLine("        INFORMACION DEL ESTUDIANTE");
        Console.WriteLine("========================================");
        Console.WriteLine("Nombre: " + nombresUni[i]);
        Console.WriteLine("Carne: " + carnetsUni[i]);
        Console.WriteLine("Edad: " + edadesUni[i]);
        Console.WriteLine("Sede: " + sedes[sedesUni[i]]);
        Console.WriteLine("Facultad: " + facultades[facultadesUni[i]]);
        Console.WriteLine("Carrera: " + carreras[facultadesUni[i], carrerasUni[i]]);
        Console.WriteLine();
        MostrarMateriasAlumno(i);
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Promedios");
        Console.WriteLine("----------------------------------------");

        for (int m = 0; m < cantidadMateriasUni[i]; m++)
        {
            if (NotasMateriaUniversidadCompletas(i, m))
                Console.WriteLine(materias[materiasUni[i, m]] + ": " + PromedioMateriaUniversidad(i, m));
            else
                Console.WriteLine(materias[materiasUni[i, m]] + ": Pendiente");
        }

        if (AsistenciaUniversidadRegistrada(i))
            Console.WriteLine("Asistencia: " + PorcentajeAsistenciaUniversidad(i) + "%");
        else
            Console.WriteLine("Asistencia: Pendiente");

        MostrarEstadoUniversitario(i);
        Console.WriteLine("========================================");
    }

    static void MostrarMateriasAlumno(int indice)
    {
        Console.WriteLine("Materias:");
        if (cantidadMateriasUni[indice] == 0)
        {
            Console.WriteLine("No hay materias inscritas.");
            return;
        }

        for (int i = 0; i < cantidadMateriasUni[indice]; i++)
            Console.WriteLine((i + 1) + ". " + materias[materiasUni[indice, i]]);
    }

    static void MostrarEstadoUniversitario(int i)
    {
        bool notasCompletas = NotasEstudianteUniversidadCompletas(i);
        bool asistenciaCompleta = AsistenciaUniversidadRegistrada(i);

        if (!notasCompletas || !asistenciaCompleta)
        {
            Console.WriteLine("Estado: PENDIENTE");
            return;
        }

        bool aprobadoNotas = PromedioEstudianteUniversidad(i) >= 6.0;
        bool aprobadoAsistencia = PorcentajeAsistenciaUniversidad(i) >= 75;

        if (aprobadoNotas)
            Console.WriteLine("Aprobo por notas: SI");
        else
            Console.WriteLine("Aprobo por notas: NO");

        if (aprobadoAsistencia)
            Console.WriteLine("Aprobo por asistencia: SI");
        else
            Console.WriteLine("Aprobo por asistencia: NO");

        if (aprobadoNotas && aprobadoAsistencia)
            Console.WriteLine("Estado: APROBADO");
        else if (!aprobadoNotas && !aprobadoAsistencia)
            Console.WriteLine("Estado: REPROBADO POR NOTAS Y ASISTENCIA");
        else if (!aprobadoNotas)
            Console.WriteLine("Estado: REPROBADO POR NOTAS");
        else
            Console.WriteLine("Estado: REPROBADO POR ASISTENCIA");
    }

    static void MostrarDatosAlumnoKinder(int i)
    {
        Console.WriteLine("========================================");
        Console.WriteLine("          INFORMACION DE KINDER");
        Console.WriteLine("========================================");
        Console.WriteLine("Nombre: " + nombresKinder[i]);
        Console.WriteLine("NIE: " + niesKinder[i]);
        Console.WriteLine("Edad: " + edadesKinder[i]);
        Console.WriteLine("Sede: Santa Ana");
        Console.WriteLine("Nivel: " + nivelesKinder[nivelesKinderEst[i]]);
        Console.WriteLine("Enfermedad cronica: " + enfermedadKinder[i]);
        Console.WriteLine("Discapacidad: " + discapacidadKinder[i]);

        if (NotasKinderCompletas(i))
            Console.WriteLine("Promedio: " + PromedioKinder(i));
        else
            Console.WriteLine("Promedio: Pendiente");

        if (clasesTotalesKinder[i] > 0)
            Console.WriteLine("Asistencia: " + PorcentajeAsistenciaKinder(i) + "%");
        else
            Console.WriteLine("Asistencia: Pendiente");

        MostrarEstadoKinder(i);
        Console.WriteLine("========================================");
    }

    static void MostrarEstadoKinder(int i)
    {
        if (!NotasKinderCompletas(i) || clasesTotalesKinder[i] == 0)
        {
            Console.WriteLine("Estado: PENDIENTE");
            return;
        }

        bool aprobadoNotas = PromedioKinder(i) >= 6.0;
        bool aprobadoAsistencia = PorcentajeAsistenciaKinder(i) >= 75;

        if (aprobadoNotas && aprobadoAsistencia)
            Console.WriteLine("Estado: APROBADO");
        else if (!aprobadoNotas && !aprobadoAsistencia)
            Console.WriteLine("Estado: REPROBADO POR NOTAS Y ASISTENCIA");
        else if (!aprobadoNotas)
            Console.WriteLine("Estado: REPROBADO POR NOTAS");
        else
            Console.WriteLine("Estado: REPROBADO POR ASISTENCIA");
    }

    static void MostrarDatosEmpleado(int i)
    {
        Console.WriteLine("========================================");
        Console.WriteLine("          INFORMACION DEL EMPLEADO");
        Console.WriteLine("========================================");
        Console.WriteLine("Nombres: " + nombresEmpleado[i]);
        Console.WriteLine("Apellidos: " + apellidosEmpleado[i]);
        Console.WriteLine("DUI: " + duiEmpleado[i]);
        Console.WriteLine("Edad: " + edadEmpleado[i]);
        Console.WriteLine("Sede: " + sedes[sedeEmpleado[i]]);
        Console.WriteLine("Cargo: " + cargos[cargoEmpleado[i]]);
        Console.WriteLine("Contacto: " + contactoEmpleado[i]);
        Console.WriteLine("Estado laboral: " + estadosLaborales[estadoEmpleado[i]]);

        if (cargoEmpleado[i] == 1)
        {
            Console.WriteLine("Facultad: " + facultades[facultadEmpleado[i]]);
            Console.WriteLine("Carrera: " + carreras[facultadEmpleado[i], carreraEmpleado[i]]);
            Console.WriteLine("Materias:");
            for (int m = 0; m < cantidadMateriasDocenteUni[i]; m++)
                Console.WriteLine((m + 1) + ". " + materias[materiasDocenteUni[i, m]] + " - " + TipoMateria(materiasDocenteUni[i, m]));
        }
        else if (cargoEmpleado[i] == 2)
        {
            Console.WriteLine("Nivel de kinder: " + nivelesKinder[nivelDocenteKinder[i]]);
        }
        else if (cargoEmpleado[i] == 3)
        {
            Console.WriteLine("Facultad asignada: " + facultades[facultadEmpleado[i]]);
        }
        Console.WriteLine("========================================");
    }

    static void MostrarMateriasDisponibles(int[] disponibles, int cantidad)
    {
        Console.WriteLine("Materias disponibles:");
        for (int i = 0; i < cantidad; i++)
            Console.WriteLine((i + 1) + ". " + materias[disponibles[i]] + " - " + TipoMateria(disponibles[i]));
    }

    // CALCULOS
    static int ContarEstudiantesUniPorSede(int sede)
    {
        int contador = 0;
        for (int i = 0; i < totalEstudiantesUni; i++)
            if (sedesUni[i] == sede)
                contador++;

        return contador;
    }

    static int ContarKinderPorNivel(int nivel)
    {
        int contador = 0;
        for (int i = 0; i < totalEstudiantesKinder; i++)
            if (nivelesKinderEst[i] == nivel)
                contador++;

        return contador;
    }

    static int ObtenerMateriasPorCarrera(int facultad, int carrera, int[] disponibles)
    {
        int cantidad = 0;
        for (int i = 0; i < relacionMateria.Length; i++)
        {
            if (relacionMateriaFacultad[i] == facultad && relacionMateriaCarrera[i] == carrera && !ExisteEnVector(disponibles, cantidad, relacionMateria[i]))
            {
                disponibles[cantidad] = relacionMateria[i];
                cantidad++;
            }
        }
        return cantidad;
    }

    static bool MateriaYaInscrita(int estudiante, int materia, int hasta)
    {
        for (int i = 0; i < hasta; i++)
            if (materiasUni[estudiante, i] == materia)
                return true;

        return false;
    }

    static bool MateriaYaAsignadaDocente(int empleado, int materia, int hasta)
    {
        for (int i = 0; i < hasta; i++)
            if (materiasDocenteUni[empleado, i] == materia)
                return true;

        return false;
    }

    static bool ExisteEnVector(int[] vector, int cantidad, int valor)
    {
        for (int i = 0; i < cantidad; i++)
            if (vector[i] == valor)
                return true;

        return false;
    }

    static string TipoMateria(int materia)
    {
        if (materia == 1 || materia == 2 || materia == 3 || materia == 18)
            return "Comun";

        return "De carrera";
    }

    static double PromedioMateriaUniversidad(int estudiante, int materia)
    {
        double suma = 0;
        for (int p = 0; p < PERIODOS; p++)
            suma += promediosPeriodosUni[estudiante, materia, p];

        return Math.Round(suma / PERIODOS, 2);
    }

    static double PromedioEstudianteUniversidad(int estudiante)
    {
        double suma = 0;
        for (int m = 0; m < cantidadMateriasUni[estudiante]; m++)
            suma += PromedioMateriaUniversidad(estudiante, m);

        return Math.Round(suma / cantidadMateriasUni[estudiante], 2);
    }

    static bool NotasMateriaUniversidadCompletas(int estudiante, int materia)
    {
        for (int p = 0; p < PERIODOS; p++)
            if (!notasRegistradasUni[estudiante, materia, p])
                return false;

        return true;
    }

    static bool NotasEstudianteUniversidadCompletas(int estudiante)
    {
        if (cantidadMateriasUni[estudiante] == 0)
            return false;

        for (int m = 0; m < cantidadMateriasUni[estudiante]; m++)
            if (!NotasMateriaUniversidadCompletas(estudiante, m))
                return false;

        return true;
    }

    static bool AsistenciaUniversidadRegistrada(int estudiante)
    {
        int total = 0;
        for (int p = 0; p < PERIODOS; p++)
            total += clasesTotalesUni[estudiante, p];

        return total > 0;
    }

    static double PorcentajeAsistenciaUniversidad(int estudiante)
    {
        int total = 0;
        int asistidas = 0;
        for (int p = 0; p < PERIODOS; p++)
        {
            total += clasesTotalesUni[estudiante, p];
            asistidas += clasesAsistidasUni[estudiante, p];
        }

        if (total == 0)
            return 0;

        return Math.Round((double)asistidas / total * 100, 2);
    }

    static double PromedioKinder(int estudiante)
    {
        double suma = 0;
        for (int i = 0; i < PERIODOS; i++)
            suma += notasKinder[estudiante, i];

        return Math.Round(suma / PERIODOS, 2);
    }

    static bool NotasKinderCompletas(int estudiante)
    {
        for (int i = 0; i < PERIODOS; i++)
            if (!notasRegistradasKinder[estudiante, i])
                return false;

        return true;
    }

    static double PorcentajeAsistenciaKinder(int estudiante)
    {
        if (clasesTotalesKinder[estudiante] == 0)
            return 0;

        return Math.Round((double)clasesAsistidasKinder[estudiante] / clasesTotalesKinder[estudiante] * 100, 2);
    }

    static bool CargoDisponible(int cargo)
    {
        if (cargo == 1)
            return totalDocentesUni < MAX_DOCENTES_UNI && totalDocentes < MAX_DOCENTES;
        if (cargo == 2)
            return totalDocentesKinder < MAX_DOCENTES_KINDER && totalDocentes < MAX_DOCENTES;
        if (cargo == 3)
            return totalDecanos < MAX_DECANOS;
        if (cargo == 4)
            return totalAdministrativos < MAX_ADMINISTRATIVOS;
        if (cargo == 5)
            return totalOrdenanzas < MAX_ORDENANZAS;
        if (cargo == 6)
            return totalVigilantes < MAX_VIGILANTES;

        return false;
    }

    static void SumarCargo(int cargo)
    {
        if (cargo == 1)
        {
            totalDocentesUni++;
            totalDocentes++;
        }
        else if (cargo == 2)
        {
            totalDocentesKinder++;
            totalDocentes++;
        }
        else if (cargo == 3)
            totalDecanos++;
        else if (cargo == 4)
            totalAdministrativos++;
        else if (cargo == 5)
            totalOrdenanzas++;
        else if (cargo == 6)
            totalVigilantes++;
    }

    static void RestarCargo(int cargo)
    {
        if (cargo == 1)
        {
            totalDocentesUni--;
            totalDocentes--;
        }
        else if (cargo == 2)
        {
            totalDocentesKinder--;
            totalDocentes--;
        }
        else if (cargo == 3)
            totalDecanos--;
        else if (cargo == 4)
            totalAdministrativos--;
        else if (cargo == 5)
            totalOrdenanzas--;
        else if (cargo == 6)
            totalVigilantes--;
    }

    // BUSQUEDAS
    static int BuscarCarnet(string carnet, int ignorar)
    {
        for (int i = 0; i < totalEstudiantesUni; i++)
            if (i != ignorar && carnetsUni[i] == carnet)
                return i;

        return -1;
    }

    static int BuscarNIE(string nie)
    {
        for (int i = 0; i < totalEstudiantesKinder; i++)
            if (niesKinder[i] == nie)
                return i;

        return -1;
    }

    static int BuscarDUI(string dui, int ignorar)
    {
        for (int i = 0; i < totalEmpleados; i++)
            if (i != ignorar && duiEmpleado[i] == dui)
                return i;

        return -1;
    }

    static string GenerarNIE()
    {
        int numero = (int)(DateTime.Now.Ticks % 9000000) + 1000000 + totalEstudiantesKinder;
        string nuevo = "NIE" + numero;

        while (BuscarNIE(nuevo) != -1)
        {
            numero++;
            if (numero > 9999999)
                numero = 1000000;
            nuevo = "NIE" + numero;
        }

        return nuevo;
    }

    // COPIAS
    static void CopiarAlumnoUniversitario(int destino, int origen)
    {
        nombresUni[destino] = nombresUni[origen];
        carnetsUni[destino] = carnetsUni[origen];
        edadesUni[destino] = edadesUni[origen];
        sedesUni[destino] = sedesUni[origen];
        facultadesUni[destino] = facultadesUni[origen];
        carrerasUni[destino] = carrerasUni[origen];
        cantidadMateriasUni[destino] = cantidadMateriasUni[origen];

        for (int m = 0; m < MAX_MATERIAS_ESTUDIANTE; m++)
        {
            materiasUni[destino, m] = materiasUni[origen, m];
            for (int p = 0; p < PERIODOS; p++)
            {
                cantidadActividadesUni[destino, m, p] = cantidadActividadesUni[origen, m, p];
                parcialesUni[destino, m, p] = parcialesUni[origen, m, p];
                promediosPeriodosUni[destino, m, p] = promediosPeriodosUni[origen, m, p];
                notasRegistradasUni[destino, m, p] = notasRegistradasUni[origen, m, p];
                for (int a = 0; a < MAX_ACTIVIDADES; a++)
                    actividadesUni[destino, m, p, a] = actividadesUni[origen, m, p, a];
            }
        }

        for (int p = 0; p < PERIODOS; p++)
        {
            clasesTotalesUni[destino, p] = clasesTotalesUni[origen, p];
            clasesAsistidasUni[destino, p] = clasesAsistidasUni[origen, p];
        }
    }

    static void LimpiarAlumnoUniversitario(int indice)
    {
        nombresUni[indice] = "";
        carnetsUni[indice] = "";
        edadesUni[indice] = 0;
        sedesUni[indice] = 0;
        facultadesUni[indice] = 0;
        carrerasUni[indice] = 0;
        cantidadMateriasUni[indice] = 0;
        LimpiarNotasUniversidad(indice);
        LimpiarAsistenciaUniversidad(indice);

        for (int m = 0; m < MAX_MATERIAS_ESTUDIANTE; m++)
            materiasUni[indice, m] = 0;
    }

    static void LimpiarNotasUniversidad(int indice)
    {
        for (int m = 0; m < MAX_MATERIAS_ESTUDIANTE; m++)
        {
            for (int p = 0; p < PERIODOS; p++)
            {
                cantidadActividadesUni[indice, m, p] = 0;
                parcialesUni[indice, m, p] = 0;
                promediosPeriodosUni[indice, m, p] = 0;
                notasRegistradasUni[indice, m, p] = false;
                for (int a = 0; a < MAX_ACTIVIDADES; a++)
                    actividadesUni[indice, m, p, a] = 0;
            }
        }
    }

    static void LimpiarAsistenciaUniversidad(int indice)
    {
        for (int p = 0; p < PERIODOS; p++)
        {
            clasesTotalesUni[indice, p] = 0;
            clasesAsistidasUni[indice, p] = 0;
        }
    }

    static void CopiarAlumnoKinder(int destino, int origen)
    {
        nombresKinder[destino] = nombresKinder[origen];
        niesKinder[destino] = niesKinder[origen];
        edadesKinder[destino] = edadesKinder[origen];
        enfermedadKinder[destino] = enfermedadKinder[origen];
        discapacidadKinder[destino] = discapacidadKinder[origen];
        nivelesKinderEst[destino] = nivelesKinderEst[origen];
        clasesTotalesKinder[destino] = clasesTotalesKinder[origen];
        clasesAsistidasKinder[destino] = clasesAsistidasKinder[origen];

        for (int i = 0; i < PERIODOS; i++)
        {
            notasKinder[destino, i] = notasKinder[origen, i];
            notasRegistradasKinder[destino, i] = notasRegistradasKinder[origen, i];
        }
    }

    static void LimpiarAlumnoKinder(int indice)
    {
        nombresKinder[indice] = "";
        niesKinder[indice] = "";
        edadesKinder[indice] = 0;
        enfermedadKinder[indice] = "";
        discapacidadKinder[indice] = "";
        nivelesKinderEst[indice] = 0;
        clasesTotalesKinder[indice] = 0;
        clasesAsistidasKinder[indice] = 0;

        for (int i = 0; i < PERIODOS; i++)
        {
            notasKinder[indice, i] = 0;
            notasRegistradasKinder[indice, i] = false;
        }
    }

    static void CopiarEmpleado(int destino, int origen)
    {
        nombresEmpleado[destino] = nombresEmpleado[origen];
        apellidosEmpleado[destino] = apellidosEmpleado[origen];
        duiEmpleado[destino] = duiEmpleado[origen];
        edadEmpleado[destino] = edadEmpleado[origen];
        sedeEmpleado[destino] = sedeEmpleado[origen];
        cargoEmpleado[destino] = cargoEmpleado[origen];
        contactoEmpleado[destino] = contactoEmpleado[origen];
        estadoEmpleado[destino] = estadoEmpleado[origen];
        facultadEmpleado[destino] = facultadEmpleado[origen];
        carreraEmpleado[destino] = carreraEmpleado[origen];
        cantidadMateriasDocenteUni[destino] = cantidadMateriasDocenteUni[origen];
        nivelDocenteKinder[destino] = nivelDocenteKinder[origen];

        for (int i = 0; i < MAX_MATERIAS_DOCENTE; i++)
            materiasDocenteUni[destino, i] = materiasDocenteUni[origen, i];
    }

    static void LimpiarEmpleado(int indice)
    {
        nombresEmpleado[indice] = "";
        apellidosEmpleado[indice] = "";
        duiEmpleado[indice] = "";
        edadEmpleado[indice] = 0;
        sedeEmpleado[indice] = 0;
        cargoEmpleado[indice] = 0;
        contactoEmpleado[indice] = "";
        estadoEmpleado[indice] = 0;
        facultadEmpleado[indice] = 0;
        carreraEmpleado[indice] = 0;
        cantidadMateriasDocenteUni[indice] = 0;
        nivelDocenteKinder[indice] = 0;

        for (int i = 0; i < MAX_MATERIAS_DOCENTE; i++)
            materiasDocenteUni[indice, i] = 0;
    }

    static void AjustarIndicesDecanos(int eliminado)
    {
        for (int i = 1; i <= 4; i++)
            if (decanoEmpleado[i] > eliminado)
                decanoEmpleado[i]--;
    }

    // VALIDACIONES
    static int LeerEntero(string mensaje)
    {
        int valor;
        string entrada;
        bool valido;

        do
        {
            if (mensaje != "")
                Console.Write(mensaje);

            entrada = Console.ReadLine() ?? "";
            valido = int.TryParse(entrada, out valor);
            if (!valido)
                Console.WriteLine("Ingrese un valor valido.");
        } while (!valido);

        return valor;
    }

    static int LeerEnteroRango(string mensaje, int minimo, int maximo)
    {
        int valor;
        do
        {
            valor = LeerEntero(mensaje);
            if (valor < minimo || valor > maximo)
                Console.WriteLine("El valor debe estar entre " + minimo + " y " + maximo + ".");
        } while (valor < minimo || valor > maximo);

        return valor;
    }

    static double LeerDecimal(string mensaje)
    {
        double valor;
        string entrada;
        bool valido;

        do
        {
            Console.Write(mensaje);
            entrada = Console.ReadLine() ?? "";
            valido = double.TryParse(entrada, out valor);
            if (!valido)
                Console.WriteLine("Ingrese un valor valido.");
        } while (!valido);

        return valor;
    }

    static double LeerNota(string mensaje)
    {
        double nota;
        do
        {
            nota = LeerDecimal(mensaje);
            if (nota < 0 || nota > 10)
                Console.WriteLine("La nota debe estar entre 0 y 10.");
        } while (nota < 0 || nota > 10);

        return nota;
    }

    static int LeerEdad(string mensaje, int minimo, int maximo)
    {
        return LeerEnteroRango(mensaje, minimo, maximo);
    }

    static string LeerNombreCompleto(string mensaje)
    {
        return LeerNombreBase(mensaje, true);
    }

    static string LeerNombreSimple(string mensaje)
    {
        return LeerNombreBase(mensaje, false);
    }

    static string LeerNombreBase(string mensaje, bool completo)
    {
        string valor;
        bool valido;

        do
        {
            Console.Write(mensaje);
            valor = Console.ReadLine() ?? "";
            valor = valor.Trim();
            valido = NombreValido(valor, completo);
            if (!valido)
                Console.WriteLine("Ingrese un nombre valido.");
        } while (!valido);

        return FormatearTexto(valor);
    }

    static bool NombreValido(string valor, bool completo)
    {
        if (string.IsNullOrWhiteSpace(valor))
            return false;

        int letras = 0;
        int palabras = 0;
        bool enPalabra = false;

        for (int i = 0; i < valor.Length; i++)
        {
            char c = valor[i];
            if (char.IsDigit(c))
                return false;

            if (char.IsLetter(c))
            {
                letras++;
                if (!enPalabra)
                {
                    palabras++;
                    enPalabra = true;
                }
            }
            else if (c == ' ')
            {
                enPalabra = false;
            }
            else
            {
                return false;
            }
        }

        string bajo = valor.ToLower().Replace(" ", "");
        if (bajo.Contains("asdf") || bajo.Contains("qwerty") || bajo.Contains("prueba") || bajo.Contains("ninguno") || bajo.Contains("anonimo"))
            return false;

        if (letras < 3)
            return false;

        if (completo && palabras < 2)
            return false;

        if (LetrasIguales(bajo))
            return false;

        return true;
    }

    static bool LetrasIguales(string valor)
    {
        if (valor.Length < 4)
            return false;

        char primera = valor[0];
        for (int i = 1; i < valor.Length; i++)
            if (valor[i] != primera)
                return false;

        return true;
    }

    static string FormatearTexto(string valor)
    {
        string[] partes = valor.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string resultado = "";

        for (int i = 0; i < partes.Length; i++)
        {
            string palabra = partes[i].ToLower();
            palabra = char.ToUpper(palabra[0]) + palabra.Substring(1);

            if (i > 0)
                resultado += " ";

            resultado += palabra;
        }

        return resultado;
    }

    static string LeerCarnet(string mensaje, int ignorar)
    {
        string valor;
        bool valido;

        do
        {
            Console.Write(mensaje);
            valor = (Console.ReadLine() ?? "").Trim().ToUpper();
            valido = CarnetValido(valor);

            if (!valido)
                Console.WriteLine("Ingrese un carnet valido.");
            else if (BuscarCarnet(valor, ignorar) != -1)
            {
                Console.WriteLine("Ese carnet ya esta registrado.");
                valido = false;
            }
        } while (!valido);

        return valor;
    }

    static bool CarnetValido(string valor)
    {
        if (valor.Length < 6 || valor.Length > 12)
            return false;

        bool tieneNumero = false;

        for (int i = 0; i < valor.Length; i++)
        {
            char c = valor[i];
            if (char.IsDigit(c))
                tieneNumero = true;
            else if (!char.IsLetter(c) && c != '-')
                return false;
        }

        return tieneNumero;
    }

    static string LeerDUI(string mensaje, int ignorar)
    {
        string valor;
        bool valido;

        do
        {
            Console.Write(mensaje);
            valor = (Console.ReadLine() ?? "").Trim();
            valido = DUIValido(valor);

            if (!valido)
                Console.WriteLine("Ingrese un DUI valido.");
            else if (BuscarDUI(valor, ignorar) != -1)
            {
                Console.WriteLine("Ese DUI ya esta registrado.");
                valido = false;
            }
        } while (!valido);

        return valor;
    }

    static bool DUIValido(string valor)
    {
        if (valor.Length == 9 && valor[7] == '-')
        {
            for (int i = 0; i < 7; i++)
                if (!char.IsDigit(valor[i]))
                    return false;

            return char.IsDigit(valor[8]);
        }

        if (valor.Length == 10 && valor[8] == '-')
        {
            for (int i = 0; i < 8; i++)
                if (!char.IsDigit(valor[i]))
                    return false;

            return char.IsDigit(valor[9]);
        }

        return false;
    }

    static string LeerContacto(string mensaje)
    {
        string valor;
        bool valido;

        do
        {
            Console.Write(mensaje);
            valor = (Console.ReadLine() ?? "").Trim();
            valido = ContactoValido(valor);
            if (!valido)
                Console.WriteLine("Ingrese un contacto valido.");
        } while (!valido);

        return valor;
    }

    static bool ContactoValido(string valor)
    {
        if (valor.Length < 7)
            return false;

        for (int i = 0; i < valor.Length; i++)
        {
            char c = valor[i];
            if (!char.IsLetterOrDigit(c) && c != ' ' && c != '-' && c != '+' && c != '@' && c != '.' && c != '_')
                return false;
        }

        return true;
    }

    static string LeerSiNo(string mensaje)
    {
        string valor;
        do
        {
            Console.Write(mensaje);
            valor = (Console.ReadLine() ?? "").Trim().ToUpper();
            if (valor == "SI" || valor == "SÍ")
                return "SI";
            if (valor == "NO")
                return "NO";

            Console.WriteLine("Ingrese SI o NO.");
        } while (true);
    }

    static void Pausar()
    {
        Console.WriteLine("Presione cualquier tecla para continuar.");
        Console.ReadKey();
    }
}
