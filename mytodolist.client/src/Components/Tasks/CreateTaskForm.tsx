import { useState } from "react";


interface CreateTaskFormProps {
    onCreateTask(title: string): void;
}

const CreateTaskForm = ({ onCreateTask }: CreateTaskFormProps) => {
    const [title, setTitle] = useState("");

    const handleTitleChange = (e) => {
        setTitle(e.target.value);
    };

    const handleCreateTask = () => {
        if (title?.length > 0) {
            onCreateTask(title);
            setTitle("");
        }
    }

    const handleKeyDown = (e) => {
        if (e.key === 'Enter') {
            handleCreateTask();
        }
    }

    return (
        <div>
            <input id="newTaskTitle" type="text" value={title} autoComplete="off" onKeyDown={handleKeyDown} onChange={handleTitleChange} />
            <button onClick={handleCreateTask}>Add</button>
        </div>
    );
}

export default CreateTaskForm