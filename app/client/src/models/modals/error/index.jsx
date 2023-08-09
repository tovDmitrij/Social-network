import React from "react";
import styles from "./styles.module.scss";

const ErrorModalWindow = ({ setIsOpen, error }) => {
    return (
      <>
          <div className={styles.background} onClick={() => setIsOpen(false)} />

          <div className={styles.modal}>
              <h1>
                  <i className="fa-solid fa-circle-exclamation"></i> Ошибка
              </h1>
              
              <p>{error}</p>
          </div>
      </>
    );
  };

export default ErrorModalWindow;