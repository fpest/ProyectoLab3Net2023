-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 28-02-2023 a las 03:35:20
-- Versión del servidor: 10.4.22-MariaDB
-- Versión de PHP: 8.1.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `proyectolab3`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `carrera`
--

CREATE TABLE `carrera` (
  `id` int(11) NOT NULL,
  `descripcion` varchar(20) NOT NULL,
  `ciclolectivo` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `carrera`
--

INSERT INTO `carrera` (`id`, `descripcion`, `ciclolectivo`) VALUES
(17, 'Matematicas', 2023),
(18, 'Quimica', 2023);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cuentacorriente`
--

CREATE TABLE `cuentacorriente` (
  `id` int(11) NOT NULL,
  `descripcion` varchar(50) NOT NULL,
  `monto` decimal(10,0) NOT NULL,
  `fechahora` datetime NOT NULL,
  `personaid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `cuentacorriente`
--

INSERT INTO `cuentacorriente` (`id`, `descripcion`, `monto`, `fechahora`, `personaid`) VALUES
(1, 'Cuota Enero', '1000', '2023-02-20 23:15:19', 1),
(2, 'Cuota Enero', '1000', '2023-02-20 23:15:19', 1),
(3, 'Cuota Marzo', '1000', '2023-02-20 23:15:58', 1),
(4, 'Cuota Abril', '1000', '2023-02-20 23:15:58', 1),
(5, 'Pago', '-1500', '2023-01-03 19:16:39', 1),
(6, 'Pago', '-800', '2023-02-17 19:16:39', 1),
(7, 'Cuota Mayo', '1000', '2023-04-13 20:19:07', 1),
(8, 'Cuota Marzo', '1000', '2023-02-21 00:19:07', 1),
(9, 'Cuota Junio', '1000', '2023-02-21 00:20:37', 1),
(10, 'Cuota Julio', '1000', '2023-02-21 00:20:37', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `inscripcionc`
--

CREATE TABLE `inscripcionc` (
  `id` int(11) NOT NULL,
  `personaid` int(11) NOT NULL,
  `carreraid` int(11) NOT NULL,
  `fechahora` date NOT NULL,
  `estado` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `inscripcionc`
--

INSERT INTO `inscripcionc` (`id`, `personaid`, `carreraid`, `fechahora`, `estado`) VALUES
(1422, 1, 18, '2023-01-01', 'Disponible'),
(1423, 1, 17, '2023-02-27', 'Vigente');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `inscripcionm`
--

CREATE TABLE `inscripcionm` (
  `id` int(11) NOT NULL,
  `personaid` int(11) NOT NULL,
  `materiaid` int(11) NOT NULL,
  `fechahora` datetime NOT NULL,
  `estado` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `inscripcionm`
--

INSERT INTO `inscripcionm` (`id`, `personaid`, `materiaid`, `fechahora`, `estado`) VALUES
(964, 1, 17, '2023-01-01 00:00:00', 'Disponible'),
(965, 1, 20, '2023-01-01 00:00:00', 'Disponible'),
(966, 1, 16, '2023-02-27 22:55:10', 'Vigente');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `materia`
--

CREATE TABLE `materia` (
  `id` int(11) NOT NULL,
  `descripcion` varchar(20) NOT NULL,
  `carreraid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `materia`
--

INSERT INTO `materia` (`id`, `descripcion`, `carreraid`) VALUES
(16, 'Mate1', 17),
(17, 'Mate2', 17),
(20, 'Quim1', 18);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `notificaciones`
--

CREATE TABLE `notificaciones` (
  `id` int(11) NOT NULL,
  `personaid` int(11) NOT NULL,
  `fecha` date NOT NULL,
  `asunto` varchar(100) NOT NULL,
  `mensaje` varchar(400) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `persona`
--

CREATE TABLE `persona` (
  `id` int(11) NOT NULL,
  `nombre` varchar(50) NOT NULL,
  `apellido` varchar(50) NOT NULL,
  `dni` varchar(20) NOT NULL,
  `email` varchar(100) NOT NULL,
  `pass` varchar(100) NOT NULL,
  `rol` varchar(20) NOT NULL,
  `token` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `persona`
--

INSERT INTO `persona` (`id`, `nombre`, `apellido`, `dni`, `email`, `pass`, `rol`, `token`) VALUES
(1, 'Federico', 'Pestchanker', '22140491', 'federico@ncdsanluis.com.ar', 'GAKKw6Co5EiIGNiZC1OfQC6offL+e8CoEs3SX0LIrHA=', 'Alumno', 'f5-z1zwARNCFdSGbtxkQFP:APA91bFLVZN_Sr3oSt1fb1EqFqxCQH3DpSysRmxmiuAlsytjVthA6gxq_9Lawf8OKaMCFnz4fIbsIvfkGa_U2MA9qF1XAuVhccYU4MkY8VtMz8NYKVRxl1uor2tlj8PXGeC-aRx6kqkU'),
(2, 'Ramiro', 'Seijas', '22939930', 'ramiro@gmail.com', 'GAKKw6Co5EiIGNiZC1OfQC6offL+e8CoEs3SX0LIrHA=', 'Alumno', 'f5-z1zwARNCFdSGbtxkQFP:APA91bFLVZN_Sr3oSt1fb1EqFqxCQH3DpSysRmxmiuAlsytjVthA6gxq_9Lawf8OKaMCFnz4fIbsIvfkGa_U2MA9qF1XAuVhccYU4MkY8VtMz8NYKVRxl1uor2tlj8PXGeC-aRx6kqkU'),
(3, 'Teresa', 'Fernandez', '18591694', 'tere@gmail.com', 'GAKKw6Co5EiIGNiZC1OfQC6offL+e8CoEs3SX0LIrHA=', 'Alumno', 'f5-z1zwARNCFdSGbtxkQFP:APA91bFLVZN_Sr3oSt1fb1EqFqxCQH3DpSysRmxmiuAlsytjVthA6gxq_9Lawf8OKaMCFnz4fIbsIvfkGa_U2MA9qF1XAuVhccYU4MkY8VtMz8NYKVRxl1uor2tlj8PXGeC-aRx6kqkU');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `registronotas`
--

CREATE TABLE `registronotas` (
  `id` int(11) NOT NULL,
  `nota` double NOT NULL,
  `fecha` date NOT NULL,
  `inscripcionmid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `carrera`
--
ALTER TABLE `carrera`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `descripcion` (`descripcion`,`ciclolectivo`);

--
-- Indices de la tabla `cuentacorriente`
--
ALTER TABLE `cuentacorriente`
  ADD PRIMARY KEY (`id`),
  ADD KEY `personaid` (`personaid`);

--
-- Indices de la tabla `inscripcionc`
--
ALTER TABLE `inscripcionc`
  ADD PRIMARY KEY (`id`),
  ADD KEY `personacarre` (`personaid`),
  ADD KEY `carreraper` (`carreraid`);

--
-- Indices de la tabla `inscripcionm`
--
ALTER TABLE `inscripcionm`
  ADD PRIMARY KEY (`id`),
  ADD KEY `personaid` (`personaid`),
  ADD KEY `materiaid` (`materiaid`);

--
-- Indices de la tabla `materia`
--
ALTER TABLE `materia`
  ADD PRIMARY KEY (`id`),
  ADD KEY `carreraid` (`carreraid`);

--
-- Indices de la tabla `notificaciones`
--
ALTER TABLE `notificaciones`
  ADD PRIMARY KEY (`id`),
  ADD KEY `depersona` (`personaid`);

--
-- Indices de la tabla `persona`
--
ALTER TABLE `persona`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `registronotas`
--
ALTER TABLE `registronotas`
  ADD PRIMARY KEY (`id`),
  ADD KEY `inscripcion` (`inscripcionmid`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `carrera`
--
ALTER TABLE `carrera`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT de la tabla `cuentacorriente`
--
ALTER TABLE `cuentacorriente`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT de la tabla `inscripcionc`
--
ALTER TABLE `inscripcionc`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1424;

--
-- AUTO_INCREMENT de la tabla `inscripcionm`
--
ALTER TABLE `inscripcionm`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=967;

--
-- AUTO_INCREMENT de la tabla `materia`
--
ALTER TABLE `materia`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT de la tabla `notificaciones`
--
ALTER TABLE `notificaciones`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `persona`
--
ALTER TABLE `persona`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `registronotas`
--
ALTER TABLE `registronotas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `cuentacorriente`
--
ALTER TABLE `cuentacorriente`
  ADD CONSTRAINT `cuentacorriente_ibfk_1` FOREIGN KEY (`personaid`) REFERENCES `persona` (`id`);

--
-- Filtros para la tabla `inscripcionc`
--
ALTER TABLE `inscripcionc`
  ADD CONSTRAINT `inscripcionc_ibfk_1` FOREIGN KEY (`personaid`) REFERENCES `persona` (`id`),
  ADD CONSTRAINT `inscripcionc_ibfk_2` FOREIGN KEY (`carreraid`) REFERENCES `carrera` (`id`);

--
-- Filtros para la tabla `inscripcionm`
--
ALTER TABLE `inscripcionm`
  ADD CONSTRAINT `inscripcionm_ibfk_1` FOREIGN KEY (`personaid`) REFERENCES `persona` (`id`),
  ADD CONSTRAINT `inscripcionm_ibfk_2` FOREIGN KEY (`materiaid`) REFERENCES `materia` (`id`);

--
-- Filtros para la tabla `materia`
--
ALTER TABLE `materia`
  ADD CONSTRAINT `materia_ibfk_1` FOREIGN KEY (`carreraid`) REFERENCES `carrera` (`id`);

--
-- Filtros para la tabla `notificaciones`
--
ALTER TABLE `notificaciones`
  ADD CONSTRAINT `notificaciones_ibfk_1` FOREIGN KEY (`personaid`) REFERENCES `persona` (`id`);

--
-- Filtros para la tabla `registronotas`
--
ALTER TABLE `registronotas`
  ADD CONSTRAINT `registronotas_ibfk_1` FOREIGN KEY (`inscripcionmid`) REFERENCES `inscripcionm` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
