import ToDoTaskView from "../../Models/ToDoTaskView";

interface TaskActionsProps {
    task: ToDoTaskView;
    onStartEditingTask(id: number): void;
    onDeleteTask(id: number): void;
    onCompleteTask(id: number): void;
}

const TaskActions = (props: TaskActionsProps) => {
    const { task, onStartEditingTask, onDeleteTask, onCompleteTask } = props;

    const completeButton =
        <>
            <button style={{ width: '160px' }} title={task.isCompleted ? "Completed" : "Complete"} disabled={task.isCompleted} onClick={() => onCompleteTask(task.id)}>{task.isCompleted ? "Done" : "mark as completed"}</button>
        </>;

    const editButton =
        <>
            <button title="Edit" disabled={task.isCompleted} onClick={() => onStartEditingTask(task.id)}>Edit</button>
        </>;

    const deleteButton =
        <>
            <a href='#' title="Delete" onClick={() => onDeleteTask(task.id)}>Delete</a>
        </>;

    return (
        <div className="actionsWrapper">
            <span>
                {completeButton}
            </span>
            <span>
                {editButton}
            </span>
            <span>
                {deleteButton}
            </span>
        </div>
    );
}

export default TaskActions;