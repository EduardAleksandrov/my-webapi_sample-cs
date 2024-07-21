-- /home/eduard/.local/share/DBeaverData/workspace6/General/Scripts

-- База данных программы обучающих курсов
create database onedb;

CREATE TABLE departments
(
    Id_department SERIAL,
    dep_name CHARACTER VARYING(150),
    dep_manager CHARACTER VARYING(100)
);

INSERT INTO departments (dep_name, dep_manager) 
VALUES 
('финансовый отдел', 'Сидоров Алексей Сергеевич'),
('Отдел информационных технологий', 'Tomson Mike'),
('Отдел редактирования обучающих курсов', 'Кимчин Иван Николаевич');