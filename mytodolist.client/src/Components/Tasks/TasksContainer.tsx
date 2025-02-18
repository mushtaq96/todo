import { useEffect, useState } from "react";
import './TaskContainer.css'
import ToDoTaskView from "../../Models/ToDoTaskView";
import TaskList from "./TaskList";
import CreateTaskForm from "./CreateTaskForm";
import TodoTask_draft from "../../Models/TodoTask_draft";
import ToDoTaskEditDraft from "../../Models/ToDoTaskEditDraft";

const TasksContainer = () => {
    const [tasks, setTasks] = useState<ToDoTaskView[]>([]);

    const getAllTasks = async () => {
        const response = await fetch('https://localhost:7017/tasks');
        const data = await response.json();
        setTasks(data);
    }

    const onCompleteTask = async (id: number) => {
        await fetch(`https://localhost:7017/tasks/completed/${id}`, { method: 'POST' });
        await getAllTasks();
    }

    const onStartEditingTaskTask = async (id: number) => {
        setTasks(tasks.map(t => { return { ...t, isInEdit: t.isInEdit || t.id === id } }));
    }

    const onSaveChanges = (taskDraft: ToDoTaskEditDraft) => {
        console.log(taskDraft);
        setTasks(tasks.map(t => { return { ...t, isInEdit: t.isInEdit && t.id !== taskDraft.id } }))
    }

    const onDeleteTask = async (id: number) => {
        await fetch(`https://localhost:7017/tasks/${id}`, { method: 'DELETE' });
        await getAllTasks();
    }

    const onCreateTask = async (title: string) => {
        const taskDraft: TodoTask_draft = { title: title };

        await fetch(`https://localhost:7017/tasks`, {
            method: 'POST',
            body: JSON.stringify(taskDraft),
            headers: {
                "Content-type": "application/json; charset=UTF-8"
            }
        });
        await getAllTasks();
    }

    useEffect(() => {
        getAllTasks();
    }, []);

    return <>
        <CreateTaskForm onCreateTask={onCreateTask} />
        <TaskList tasks={tasks} onCompleteTask={onCompleteTask} onDeleteTask={onDeleteTask} onStartEditingTask={onStartEditingTaskTask} onSaveChanges={onSaveChanges} />
    </>;
}

export default TasksContainer;