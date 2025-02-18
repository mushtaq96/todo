
import ToDoTaskEditDraft from "../../Models/ToDoTaskEditDraft";
import ToDoTaskView from "../../Models/ToDoTaskView";
import TaskDetails from "./TaskDetails";

interface task_Listpops {
    tasks: ToDoTaskView[];
    onStartEditingTask(id: number): void;
    onSaveChanges(taskDraft: ToDoTaskEditDraft): void;
    onDeleteTask(id: number): void;
    onCompleteTask(id: number): void;
}

const TaskList = (props: task_Listpops) => {
    const { tasks, onStartEditingTask, onSaveChanges, onDeleteTask, onCompleteTask } = props;

    return (
        <ul>
            {tasks?.map(task =>
                <li>
                    <TaskDetails task={task} onStartEditingTask={onStartEditingTask} onSaveChanges={onSaveChanges} onDeleteTask={onDeleteTask} onCompleteTask={onCompleteTask} />                    
                </li>
            )}
        </ul>);
}

export default TaskList;