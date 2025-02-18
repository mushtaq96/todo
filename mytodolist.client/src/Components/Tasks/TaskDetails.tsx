import ToDoTaskEditDraft from "../../Models/ToDoTaskEditDraft";
import ToDoTaskView from "../../Models/ToDoTaskView";
import TaskActions from "./TaskActions";
import TaskEditForm from "./TaskEditForm";

interface TaskDetailsProps {
    task: ToDoTaskView;
    onStartEditingTask(id: number): void;
    onSaveChanges(taskDraf: ToDoTaskEditDraft): void;
    onDeleteTask(id: number): void;
    onCompleteTask(id: number): void;
}

const TaskDetails = (props: TaskDetailsProps) => {
    const { task, onStartEditingTask, onSaveChanges, onDeleteTask, onCompleteTask } = props;

    const title = task.isInEdit ? <TaskEditForm task={task} onSaveChanges={onSaveChanges} /> : <span style={{ textDecoration: task.isCompleted ? 'line-through' : 'none', overflow: "auto", height: "30px" }}>{task.title}</span>

    return (
        <div className="taskWrapper">
            { title }
            <TaskActions task={task} onStartEditingTask={onStartEditingTask} onDeleteTask={onDeleteTask} onCompleteTask={onCompleteTask} />
        </div>
    );
}

export default TaskDetails;